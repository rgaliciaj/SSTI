using Azure;
using Azure.Core;
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
                var estadosTicket = ObtenerEstadosTicket();
                var rutaUsuario = ObtenerRutaUsuario(request.CODIGO_USUARIO);
                var tecnicoAsignado = ObtenerTecnico(rutaUsuario[0].CODIGO_RUTA);


                if (tecnicoAsignado.Count > 0)
                {
                    if (estadosTicket.Count > 0 && rutaUsuario.Count > 0)
                    {
                        foreach (var e in estadosTicket)
                        {
                            if (string.Equals(e.NOMBRE_ESTADO, "CREADO", StringComparison.OrdinalIgnoreCase))
                            {
                                request.ESTADO_TICKET = e.CODIGO_ESTADO;
                                Debug.WriteLine("CODIGO ENCONTRADOOOO: " + request.ESTADO_TICKET);
                                break;
                            }
                        }

                        //asignacion de ruta
                        request.RUTA = rutaUsuario[0].CODIGO_RUTA;
                        request.CODIGO_TECNICO = tecnicoAsignado[0].TECNICO_ASIGNADO;

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

                        if (result)
                        {
                            var response = new
                            {
                                codigo = codigo.ToUpper(),
                                mensaje = "Ticket creado exitosamente.",
                                resultado = result
                            };

                            return Ok(response);

                        }
                        else
                        {
                            var response = new
                            {
                                codigo = "",
                                mensaje = "Error al crear ticket.",
                                resultado = false
                            };
                            return Ok(response);
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            codigo = "",
                            mensaje = "Error al crear ticket.",
                            resultado = false
                        };
                        return Ok(response);
                    }

                }
                else
                {
                    var response = new
                    {
                        codigo = "",
                        mensaje = "No existe un técnico disponible para esta ruta.",
                        resultado = false
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }
        }

        [HttpPut("ActualizarTicket")]
        public IActionResult ActualizarTicket([FromBody] TicketModel request)
        {
            try
            {
                var ticketActual = ObtenerTicket(request.CODIGO_TICKET);
                var estadosTicket = ObtenerEstadosTicket();

                if (ticketActual.Count > 0 && estadosTicket.Count > 0)
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
                                var response = new
                                {
                                    codigo = "",
                                    mensaje = "Error, no se puede modificar un ticket cerrado/resuelto.",
                                    resultado = false
                                };
                                return Ok(response);
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
                                            DESCRIPCION = request.DESCRIPCION,
                                            ESTADO_TICKET = nuevoEstado,
                                            CODIGO_PRIORIDAD = request.CODIGO_PRIORIDAD,
                                            CODIGO_RECURSO = request.CODIGO_RECURSO,
                                            FECHA_MODIFICACION = request.FECHA_MODIFICACION
                                        });

                                    Debug.WriteLine("Query: " + query);

                                    var sql = execute.ExecuterCompiler(query);

                                    Debug.WriteLine("sql: " + sql);

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

        [HttpPut("CambioEstadoPendiente")]
        public IActionResult CambioEstadoPendiente(string id)
        {
            try
            {
                var ticketValido = TicketId(id);
                var estados = ObtenerEstadosTicket();
                var nuevoEstado = "";

                if (ticketValido.Count > 0)
                {
                    if (estados.Count > 0)
                    {
                        foreach (var e in estados)
                        {
                            if (string.Equals(e.NOMBRE_ESTADO, "PENDIENTE", StringComparison.OrdinalIgnoreCase))
                            {
                                nuevoEstado = e.CODIGO_ESTADO;
                                Debug.WriteLine("CODIGO ENCONTRADOOOO: " + nuevoEstado);
                                break;
                            }
                        }

                        try
                        {
                            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                            var connection = new ConectionDecider();

                            connection.InitRead();

                            var query = new Query("TICKET")
                                .Where("CODIGO_TICKET", id)
                                .AsUpdate(new
                                {
                                    ESTADO_TICKET = nuevoEstado
                                });

                            Debug.WriteLine("Query: " + query);

                            var sql = execute.ExecuterCompiler(query);

                            Debug.WriteLine("sql: " + sql);

                            return Ok(execute.ExecuteDecider(sql));

                        }
                        catch (Exception ex)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            codigo = "",
                            mensaje = "Error al modificar estado de ticket.",
                            resultado = false
                        };
                        return Ok(response);
                    }
                }
                else
                {
                    var response = new
                    {
                        codigo = "",
                        mensaje = "Error, ticket no existe.",
                        resultado = false
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        [HttpPut("CambioEstadoEnEspera")]
        public IActionResult CambioEstadoEnEspera(string id)
        {
            try
            {
                var ticketValido = TicketId(id);
                var estados = ObtenerEstadosTicket();
                var nuevoEstado = "";

                if (ticketValido.Count > 0)
                {
                    if (estados.Count > 0)
                    {
                        foreach (var e in estados)
                        {
                            if (e.NOMBRE_ESTADO.ToUpper().Contains("ESPERA"))
                            {
                                nuevoEstado = e.CODIGO_ESTADO;
                                Debug.WriteLine("CODIGO ENCONTRADOOOO: " + nuevoEstado);
                                break;
                            }
                        }

                        try
                        {
                            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                            var connection = new ConectionDecider();

                            connection.InitRead();

                            var query = new Query("TICKET")
                                .Where("CODIGO_TICKET", id)
                                .AsUpdate(new
                                {
                                    ESTADO_TICKET = nuevoEstado
                                });

                            Debug.WriteLine("Query: " + query);

                            var sql = execute.ExecuterCompiler(query);

                            Debug.WriteLine("sql: " + sql);

                            return Ok(execute.ExecuteDecider(sql));

                        }
                        catch (Exception ex)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            codigo = "",
                            mensaje = "Error al modificar estado de ticket.",
                            resultado = false
                        };
                        return Ok(response);
                    }
                }
                else
                {
                    var response = new
                    {
                        codigo = "",
                        mensaje = "Error, ticket no existe.",
                        resultado = false
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        [HttpPut("CambioEstadoReasignado")]
        public IActionResult CambioEstadoReasignado(string id)
        {
            try
            {
                var ticketValido = TicketId(id);
                var estados = ObtenerEstadosTicket();
                var nuevoEstado = "";

                if (ticketValido.Count > 0)
                {
                    if (estados.Count > 0)
                    {
                        foreach (var e in estados)
                        {
                            if (string.Equals(e.NOMBRE_ESTADO, "REASIGNADO", StringComparison.OrdinalIgnoreCase))
                            {
                                nuevoEstado = e.CODIGO_ESTADO;
                                Debug.WriteLine("CODIGO ENCONTRADOOOO: " + nuevoEstado);
                                break;
                            }
                        }

                        try
                        {
                            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                            var connection = new ConectionDecider();

                            connection.InitRead();

                            var query = new Query("TICKET")
                                .Where("CODIGO_TICKET", id)
                                .AsUpdate(new
                                {
                                    ESTADO_TICKET = nuevoEstado
                                });

                            Debug.WriteLine("Query: " + query);

                            var sql = execute.ExecuterCompiler(query);

                            Debug.WriteLine("sql: " + sql);

                            return Ok(execute.ExecuteDecider(sql));

                        }
                        catch (Exception ex)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            codigo = "",
                            mensaje = "Error al modificar estado de ticket.",
                            resultado = false
                        };
                        return Ok(response);
                    }
                }
                else
                {
                    var response = new
                    {
                        codigo = "",
                        mensaje = "Error, ticket no existe.",
                        resultado = false
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        [HttpPut("CambioEstadoResuelto")]
        public IActionResult CambioEstadoResuelto(string id)
        {
            try
            {
                var ticketValido = TicketId(id);
                var estados = ObtenerEstadosTicket();
                var nuevoEstado = "";

                if (ticketValido.Count > 0)
                {
                    if (estados.Count > 0)
                    {
                        foreach (var e in estados)
                        {
                            if (string.Equals(e.NOMBRE_ESTADO, "RESUELTO", StringComparison.OrdinalIgnoreCase))
                            {
                                nuevoEstado = e.CODIGO_ESTADO;
                                Debug.WriteLine("CODIGO ENCONTRADOOOO: " + nuevoEstado);
                                break;
                            }
                        }

                        try
                        {
                            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                            var connection = new ConectionDecider();

                            connection.InitRead();

                            var query = new Query("TICKET")
                                .Where("CODIGO_TICKET", id)
                                .AsUpdate(new
                                {
                                    ESTADO_TICKET = nuevoEstado
                                });

                            Debug.WriteLine("Query: " + query);

                            var sql = execute.ExecuterCompiler(query);

                            Debug.WriteLine("sql: " + sql);

                            return Ok(execute.ExecuteDecider(sql));

                        }
                        catch (Exception ex)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            codigo = "",
                            mensaje = "Error al modificar estado de ticket.",
                            resultado = false
                        };
                        return Ok(response);
                    }
                }
                else
                {
                    var response = new
                    {
                        codigo = "",
                        mensaje = "Error, ticket no existe.",
                        resultado = false
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        [HttpPut("CambioEstadoCerrado")]
        public IActionResult CambioEstadoCerrado(string id)
        {
            try
            {
                var ticketValido = TicketId(id);
                var estados = ObtenerEstadosTicket();
                var nuevoEstado = "";

                if (ticketValido.Count > 0)
                {
                    if (estados.Count > 0)
                    {
                        foreach (var e in estados)
                        {
                            if (string.Equals(e.NOMBRE_ESTADO, "CERRADO", StringComparison.OrdinalIgnoreCase))
                            {
                                nuevoEstado = e.CODIGO_ESTADO;
                                Debug.WriteLine("CODIGO ENCONTRADOOOO: " + nuevoEstado);
                                break;
                            }
                        }

                        try
                        {
                            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                            var connection = new ConectionDecider();

                            connection.InitRead();

                            var query = new Query("TICKET")
                                .Where("CODIGO_TICKET", id)
                                .AsUpdate(new
                                {
                                    ESTADO_TICKET = nuevoEstado
                                });

                            Debug.WriteLine("Query: " + query);

                            var sql = execute.ExecuterCompiler(query);

                            Debug.WriteLine("sql: " + sql);

                            return Ok(execute.ExecuteDecider(sql));

                        }
                        catch (Exception ex)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
                        }
                    }
                    else
                    {
                        var response = new
                        {
                            codigo = "",
                            mensaje = "Error al modificar estado de ticket.",
                            resultado = false
                        };
                        return Ok(response);
                    }
                }
                else
                {
                    var response = new
                    {
                        codigo = "",
                        mensaje = "Error, ticket no existe.",
                        resultado = false
                    };
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error con el servidor: {ex.Message}");
            }

        }

        // DELETE api/<TicketController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        private List<EstadosModel> ObtenerEstadosTicket()
        {
            var listEstadoTicket = new List<EstadosModel>();

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
                    listEstadoTicket = DataReaderMapper<EstadosModel>.MapToList(reader);
                });

                return listEstadoTicket;

            }
            catch (Exception ex)
            {
                return listEstadoTicket;
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


        private List<UsuariosModel> ObtenerRutaUsuario(string id)
        {
            var list = new List<UsuariosModel>();
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("USUARIOS").Select("*").Where("CODIGO_USUARIO", id);

                var sql = execute.ExecuterCompiler(query);

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<UsuariosModel>.MapToList(reader);
                });

                return list.ToList();
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        private List<RutasModel> ObtenerTecnico(string id)
        {

            var list = new List<RutasModel>();
            try
            {
                ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

                var connection = new ConectionDecider();

                var query = new Query("RUTA").Select("*").Where("CODIGO_RUTA", id);

                var sql = execute.ExecuterCompiler(query);

                execute.DataReader(sql, reader =>
                {
                    list = DataReaderMapper<RutasModel>.MapToList(reader);
                });

                return list.ToList();
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        private List<TicketModel> TicketId(string id)
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

    }
}
