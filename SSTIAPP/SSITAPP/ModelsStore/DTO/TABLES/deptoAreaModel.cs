using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class DeptoAreaModel
    {
        [JsonPropertyName("CODIGO_DEPTO_AREA")]
        public string CODIGO_DEPTO_AREA { get; set; }
        [JsonPropertyName("NOMBRE_DEPTO_AREA")]
        public string NOMBRE_DEPTO_AREA { get; set; }
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO { get; set; }
        [JsonPropertyName("DEPTO_AREA_PADRE")]
        public string DEPTO_AREA_PADRE { get; set; }
    }
}
