using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class EstadosModel
    {
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO {  get; set; }
        [JsonPropertyName("NOMBRE_ESTADO")]
        public string NOMBRE_ESTADO { get; set;}
        [JsonPropertyName("TIPO_ESTADO")]
        public string TIPO_ESTADO { get; set;}
    }
}
