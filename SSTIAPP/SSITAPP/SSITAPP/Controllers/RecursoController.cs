using Azure.Core;
using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;
using SqlKata;
using System.Diagnostics;

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecursoController : ControllerBase
    {
        [HttpGet("ObtenerListadoRecursos")]
        public IActionResult ObtenerListadoRecursos()
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("RECURSOS_INFORMATICOS").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var list = new List<RecursoInformaticoModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<RecursoInformaticoModel>.MapToList(reader);
                });

                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        private List<EstadosModel> ObtenerEstadosRecurso()
        {
            var listEstadoRecurso = new List<EstadosModel>();

            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                connection.InitRead();

                var queryTipoEstado = new Query("TIPO_ESTADO").Where("NOMBRE_TIPO_ESTADO", "TIPO_TICKET").Limit(1);

                var sqlTipoEstado = execute.ExecuterCompiler(queryTipoEstado);

                var tipoEstado = new List<TipoEstadoModel>();

                execute.DataReader(sqlTipoEstado, reader =>
                {
                    tipoEstado = DataReaderMapper<TipoEstadoModel>.MapToList(reader);
                });

                var queryEstado = new Query("ESTADOS").Select("*").Where("TIPO_ESTADO", tipoEstado[0].CODIGO_TIPO_ESTADO);

                var sqlEstado = execute.ExecuterCompiler(queryEstado);

                execute.DataReader(sqlEstado, reader =>
                {
                    listEstadoRecurso = DataReaderMapper<EstadosModel>.MapToList(reader);
                });

                return listEstadoRecurso;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return listEstadoRecurso;
            }
        }
    }
}
