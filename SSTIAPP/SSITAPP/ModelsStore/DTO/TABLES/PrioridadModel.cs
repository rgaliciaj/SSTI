using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class PrioridadModel
    {
        [JsonPropertyName("CODIGO_PRIORIDAD")]
        public string CODIGO_PRIORIDAD { get; set; }
        [JsonPropertyName("NOMBRE_PRIORIDAD")]
        public string NOMBRE_PRIORIDAD { get; set; }
        [JsonPropertyName("DESCRIPCION")]
        public string DESCRIPCION {  get; set; }
    }
}
