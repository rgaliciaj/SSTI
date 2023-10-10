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
        [HttpPost("obtenerEstado")]
        public IActionResult obtenerEstado([FromBody] ESTADOS request)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                connection.InitRead();

                var query = new Query("ESTADOS").Select("*").Where("TIPO_ESTADO", request.TIPO_ESTADO);

                var sql = execute.ExecuterCompiler(query);

                var result = new List<ESTADOS>();

                execute.DataReader(sql, reader =>
                {
                    result = DataReaderMapper<ESTADOS>.MapToList(reader);
                });

                return Ok(result.ToList());

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }

        }

        //// GET api/<EstadoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<EstadoController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EstadoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EstadoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
