using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;
using SqlKata;

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoEstadoController : ControllerBase
    {
        [HttpGet("obtenerListadoTipoEstado")]
        public IActionResult obtenerListadoTipoEstado()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var connection = new ConectionDecider();
            
            try
            {
                var query = new Query("TIPO_ESTADO").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var result = new List<TipoEstadoModel>();

                execute.DataReader(sql, reader =>
                {
                   result =  DataReaderMapper<TipoEstadoModel>.MapToList(reader);
                });

                return Ok(result.ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }
        }
    }
}
