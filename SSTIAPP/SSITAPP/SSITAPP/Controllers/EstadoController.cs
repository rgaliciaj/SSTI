using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;
using SqlKata;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        // GET: api/<EstadoController>
        [HttpGet("obtenerEstados")]
        public IActionResult obtenerEstados()
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                connection.InitRead();

                var query = new Query("ESTADOS").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var result = new List<EstadosModel>();

                execute.DataReader(sql, reader =>
                {
                    result = DataReaderMapper<EstadosModel>.MapToList(reader);
                });

                return Ok(result.ToList());

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }

        }

        [HttpGet("ObtenerEstadosTicket")]
        public IActionResult ObtenerEstadosTicket()
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                connection.InitRead();

                var queryTipoEstado = new Query("TIPO_ESTADO").Where("NOMBRE_TIPO_ESTADO", "TIPO_TICKET").Limit(1);

                var sqlTipoEstado = execute.ExecuterCompiler(queryTipoEstado);

                Debug.WriteLine("sql: " + sqlTipoEstado);

                var tipoEstado = new List<TipoEstadoModel>();

                execute.DataReader(sqlTipoEstado, reader =>
                {
                    tipoEstado = DataReaderMapper<TipoEstadoModel>.MapToList(reader);
                });

                var queryEstado = new Query("ESTADOS").Select("*").Where("TIPO_ESTADO", tipoEstado[0].CODIGO_TIPO_ESTADO);

                Debug.WriteLine("queryEstado: " + queryEstado);

                var sqlEstado = execute.ExecuterCompiler(queryEstado);

                Debug.WriteLine("sqlEstado: " + sqlEstado);

                var listEstadoTicket = new List<EstadosModel>();

                execute.DataReader(sqlEstado, reader =>
                {
                    listEstadoTicket = DataReaderMapper<EstadosModel>.MapToList(reader);
                });

                return Ok(listEstadoTicket);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocurrio un error al consultar: {ex.Message}");
            }
        }

        // GET api/<EstadoController>/5
        [HttpGet("obtenerEstado/{id}")]
        public IActionResult obtenerEstado(string id)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
                
                var connection = new ConectionDecider(); 
                
                connection.InitRead();

                var query = new Query("ESTADOS").Where("CODIGO_ESTADO", id);

                var sql = execute.ExecuterCompiler(query);

                var result = new List<EstadosModel>();

                execute.DataReader(sql, reader =>
                {
                    result = DataReaderMapper<EstadosModel>.MapToList(reader);
                });

                return Ok(result.ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }
        }

        // POST api/<EstadoController>
        [HttpPost]
        public void Post([FromBody] EstadosModel request)
        {
        }

        // PUT api/<EstadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
