using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Mvc;
using ModelsStore.DbConn.DbConect;
using ModelsStore.DTO.TABLES;
using SqlKata;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSITAPP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet("ObtenerTickets")]
        public IActionResult ObtenerTickets()
        {

            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET").Select("*");

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicket/{id}")]
        public IActionResult obtenerTicketId(string id)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET").Select("*").Where("CODIGO_TICKET", id);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketUsuario/{usuario}")]
        public IActionResult obtenerTicketUsuario(string usuario)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET").Select("*").Where("CODIGO_USUARIO", usuario);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketRangoCreacion")]
        public IActionResult obtenerTicketRangoCreacion(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*")
                    .WhereBetween("FECHA_CREACION", fechaInicio, fechaFinal);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketEstado/{estado}")]
        public IActionResult obtenerTicketEstado(string estado)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*").Where("ESTADO_TICKET", estado);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketPrioridad/{prioridad}")]
        public IActionResult obtenerTicketPrioridad(string prioridad)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*").Where("CODIGO_PRIORIDAD", prioridad);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketRangoSolucion")]
        public IActionResult obtenerTicketRangoSolucion(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*")
                    .WhereBetween("FECHA_HORA_SOLUCION", fechaInicio, fechaFinal);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketTecnico/{tecnico}")]
        public IActionResult obtenerTicketTecnico(string tecnico)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*").Where("CODIGO_TECNICO", tecnico);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketRecurso/{recurso}")]
        public IActionResult obtenerTicketRecurso(string recurso)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*").Where("CODIGO_RECURSO", recurso);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpGet("obtenerTicketRuta/{ruta}")]
        public IActionResult obtenerTicketRuta(string ruta)
        {
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET")
                    .Select("*").Where("RUTA", ruta);

                var sql = execute.ExecuterCompiler(query);

                var list = new List<TicketModel>();

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpPost("crearTicket")]
        public IActionResult crearTicket([FromBody] TicketModel request)
        {
            try
            {

                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                connection.InitRead();

                string guidString = Guid.NewGuid().ToString();

                string guidSinGuiones = guidString.Replace("-", "");

                //string digitos = new string(guidString.Where(char.IsDigit).ToArray());

                string codigo = guidSinGuiones.Substring(guidSinGuiones.Length - 12);

                Debug.WriteLine("Codigo: [" + codigo.ToUpper() + "]");

                request.CODIGO_TICKET = codigo.ToUpper();

                var query = new Query("TICKET").AsInsert(request);

                var sql = execute.ExecuterCompiler(query);

                var result = execute.ExecuteDecider(sql);

                //usuario que asigna *x
                //ubicacion o departamento: a que ruta pertenece x
                //prioridad*x
                //tecnico*x
                //descripcion del problema*x
                //dispositivo *x
                //adjuntos como imagen
                //fecha y hora de creacion*x
                //estado de confirmacion*

                //debe retornar el Número de ticket

                if (result)
                {
                    var response = new
                    {
                        codigo = codigo.ToUpper(),
                        resultado = result
                    };

                    return Ok(response);

                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpPut("actualizarTicket")]
        public IActionResult actualizarTicket([FromBody] TicketModel request)
        {

            // Formatear fecha y hora local
            DateTime now = DateTime.Now;
            string formattedLocalTime = now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("Fecha y hora local formateada: " + formattedLocalTime);

            // Formatear fecha y hora en UTC
            DateTime utcNow = DateTime.UtcNow;
            string formattedUtcTime = utcNow.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("Fecha y hora en UTC formateada: " + formattedUtcTime);


            try
            {
                var ticketActual = ObtenerTicket(request.CODIGO_TICKET);
                var estadosTicket = ObtenerEstadosTicket();

                if (ticketActual != null && estadosTicket != null)
                {
                    var nuevoEstado = "";

                    foreach (var e in estadosTicket)
                    {
                        if (string.Equals(e.NOMBRE_ESTADO, "CREADO", StringComparison.OrdinalIgnoreCase))
                        {
                            nuevoEstado = e.CODIGO_ESTADO;
                            Debug.WriteLine("CODIGO ENCONTRADOOOO: " + nuevoEstado);
                            break;
                        }
                    }

                    foreach (var e in estadosTicket)
                    {
                        if (ticketActual[0].ESTADO_TICKET == e.CODIGO_ESTADO)
                        {

                            if (string.Equals(e.NOMBRE_ESTADO, "RESUELTO", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(e.NOMBRE_ESTADO, "CERRADO", StringComparison.OrdinalIgnoreCase))
                            {
                                return Ok(false);
                            }
                            else
                            {
                                Debug.WriteLine("ESTADO MODIFICABLE");
                                try
                                {
                                    ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                                    var connection = new ConectionDecider();

                                    connection.InitRead();

                                    var query = new Query("TICKET")
                                        .Where("CODIGO_TICKET", request.CODIGO_TICKET)
                                        .AsUpdate(new
                                        {
                                            FECHA_CREACION = DateTime.UtcNow,
                                            DESCRIPCION = request.DESCRIPCION,
                                            ESTADO_TICKET = nuevoEstado,
                                            CODIGO_PRIORIDAD = request.CODIGO_PRIORIDAD,
                                            CODIGO_RECURSO = request.CODIGO_RECURSO
                                        });

                                    var sql = execute.ExecuterCompiler(query);

                                    return Ok(execute.ExecuteDecider(sql));
                                }
                                catch (Exception ex)
                                {
                                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
                                }
                            }
                        }
                    }

                    return BadRequest("No se encuentra estado o estado es inválido");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        private List<EstadosModel> ObtenerEstadosTicket()
        {
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

                var listEstadoTicket = new List<EstadosModel>();

                execute.DataReader(sqlEstado, reader =>
                {
                    listEstadoTicket = DataReaderMapper<EstadosModel>.MapToList(reader);
                });

                return listEstadoTicket;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<TicketModel> ObtenerTicket(string id)
        {
            var list = new List<TicketModel>();
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("TICKET").Select("*").Where("CODIGO_TICKET", id);

                var sql = execute.ExecuterCompiler(query);

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<TicketModel>.MapToList(reader);
                });

                return list.ToList();
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
