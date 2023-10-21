using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {
        [HttpGet("ObtenerListadoPrioridad")]
        public IActionResult ObtenerListadoPrioridad()
        {

            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new SqlKata.Query("PRIORIDAD").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var list = new List<PrioridadModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<PrioridadModel>.MapToList(reader);
                });

                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        //// GET api/<PrioridadController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PrioridadController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PrioridadController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PrioridadController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
