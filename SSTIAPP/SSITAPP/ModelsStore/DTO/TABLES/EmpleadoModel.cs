using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class EmpleadoModel
    {
        [JsonPropertyName("CODIGO_EMPLEADO")]
        public string CODIGO_EMPLEADO { get; set; }
        [JsonPropertyName("NOMBRE")]
        public string NOMBRE {  get; set; }
        [JsonPropertyName("NIT_CLIENTE")]
        public string NIT_CLIENTE { get; set; }
        [JsonPropertyName("DIRECCION_CLIENTE")]
        public string DIRECCION_CLIENTE { get; set; }
        [JsonPropertyName("COD_DEPTO_AREA")]
        public string COD_DEPTO_AREA { get; set; }
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO { get; set; }
        [JsonPropertyName("CODIGO_ROL_USUARIO")]
        public string CODIGO_ROL_USUARIO {  get; set; }
    }
}
