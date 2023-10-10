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
        [HttpGet("obtenerTipoEstado")]
        public IActionResult obtenerTipoEstado()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var connection = new ConectionDecider();
            
            try
            {
                var query = new Query("TIPO_ESTADO").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var result = new List<tipoEstadoModel>();

                execute.DataReader(sql, reader =>
                {
                    result = DataReaderMapper<tipoEstadoModel>.MapToList(reader);
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
