using ClassDB.SqlKataTools;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.Models;
using ModelsStore.DTO.PARAM;
using ModelsStore.DTO.TABLES;
using SqlKata;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ModelsStore.DbConn.Utilities
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest request)
        {
            UserResponse UserResponse = new UserResponse();

            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                string spass = EncryptData.GetSHA256(request.Password);

                var query = new 
                    Query("USUARIOS").Select("*")
                    .Where("USER_ID", request.Usuario.ToLower())
                    .Where("PASSWORD_USER", spass);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<UsuariosModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<UsuariosModel>.MapToList(reader);
                });

                foreach (var i in list)
                {
                    Debug.WriteLine("user: [" + i.USER_ID + "]");
                    Debug.WriteLine("codig: [" + i.CODIGO_USUARIO + "]");
                    Debug.WriteLine("rol: ["+i.CODIGO_ROL_USUARIO+"]");
                    Debug.WriteLine("ruta: ["+i.CODIGO_RUTA+"]");
                }

                if (list.Count > 0)
                {
                    UserResponse.Userid = list[0].USER_ID;
                    UserResponse.Usercod = list[0].CODIGO_USUARIO;
                    UserResponse.UserPrivilegio = list[0].CODIGO_ROL_USUARIO;
                    UserResponse.UserRuta = list[0].CODIGO_RUTA;
                    UserResponse.Token = GetToken(list);
                    

                    return UserResponse;

                }

                return UserResponse;

            }
            catch (Exception ex)
            {
                return UserResponse;
            }
        }

        private string GetToken(List<UsuariosModel> listUser)
        {
            Debug.WriteLine("Si ingresa acáaa");
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, listUser[0].CODIGO_USUARIO.ToString()),
                        new Claim(ClaimTypes.Name, listUser[0].USER_ID.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
