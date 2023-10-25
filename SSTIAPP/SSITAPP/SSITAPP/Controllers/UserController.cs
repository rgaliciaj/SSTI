using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.Utilities;
using ModelsStore.DTO.Models;

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("AuthUser")]
        public IActionResult AuthUser([FromBody] AuthRequest request)
        {
            try
            {
                Respuesta respuesta = new Respuesta();

                var userresponse = _userService.Auth(request);

                if (userresponse == null)
                {
                    respuesta.codigo = "9999";
                    respuesta.mensaje = "Usuario o contraseña incorrecta.";
                    return BadRequest(respuesta);
                }


                respuesta.codigo = "0000";
                respuesta.mensaje = "Bienvenido "+userresponse.Userid+"";
                respuesta.resultado = userresponse;
                return Ok(userresponse);

                
                
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
