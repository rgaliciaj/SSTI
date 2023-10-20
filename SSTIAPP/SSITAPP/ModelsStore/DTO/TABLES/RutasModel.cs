using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class RutasModel
    {
        [JsonPropertyName("CODIGO_RUTA")]
        public string CODIGO_RUTA { get; set; }
        [JsonPropertyName("NOMBRE_RUTA")]
        public string NOMBRE_RUTA { get; set;}
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO {  get; set; }
        [JsonPropertyName("TECNICO_ASIGNADO")]
        public string TECNICO_ASIGNADO { get; set; }
    }
}
