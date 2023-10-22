using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.PARAM;
using ModelsStore.DTO.TABLES;
using SqlKata;

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("login/")]
        public IActionResult Login(string usuario, string password)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("USUARIOS").Select("*").Where("USER_ID", usuario.ToUpper()).Where("PASSWORD_USER", password.ToUpper());

                var sql = execute.ExecuterCompiler(query);

                var list = new List<UsuariosModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<UsuariosModel>.MapToList(reader);
                });

                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        //[HttpPost]
        //public IActionResult Logout() { }
    }
}
