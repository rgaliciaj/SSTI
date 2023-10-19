using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class TicketModel
    {
        [JsonPropertyName("CODIGO_TICKET")]
        public string? CODIGO_TICKET { get; set; }
        [JsonPropertyName("CODIGO_USUARIO")]
        public string? CODIGO_USUARIO {  get; set; }
        [JsonPropertyName("FECHA_CREACION")]
        public DateTime FECHA_CREACION { get; set; }
        [JsonPropertyName("DESCRIPCION")]
        public string? DESCRIPCION { get; set; }
        [JsonPropertyName("ESTADO_TICKET")]
        public string? ESTADO_TICKET { get; set; }
        [JsonPropertyName("CODIGO_PRIORIDAD")]
        public string? CODIGO_PRIORIDAD {  get; set; }
        [JsonPropertyName("FECHA_HORA_SOLUCION")]
        public DateTime FECHA_HORA_SOLUCION {  get; set; }
        [JsonPropertyName("CODIGO_TECNICO")]
        public string? CODIGO_TECNICO {  get; set; }
        [JsonPropertyName("CODIGO_RECURSO")]
        public string? CODIGO_RECURSO { get; set; }
        [JsonPropertyName("RUTA")]
        public string? RUTA {  get; set; }

    }
}
