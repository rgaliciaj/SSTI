using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;
using SqlKata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet("ObtenerRoles")]
        public IActionResult ObtenerRoles()
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("ROLES_USUARIO").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var listaPreliminar = new List<RolUsuarioModel>();

                execute.DataReader(sql, reader =>
                {
                    listaPreliminar = DataReaderMapper<RolUsuarioModel>.MapToList(reader);
                });

                return Ok(listaPreliminar.ToList());
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        //// GET api/<RolesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<RolesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RolesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RolesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
