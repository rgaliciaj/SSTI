using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class TipoEstadoModel
    {
        [JsonPropertyName("CODIGO_TIPO_ESTADO")]
        public string CODIGO_TIPO_ESTADO { get; set; }
        [JsonPropertyName("NOMBRE_TIPO_ESTADO")]
        public string NOMBRE_TIPO_ESTADO { get; set; }
    }
}
