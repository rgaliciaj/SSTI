using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class RecursoInformaticoModel
    {
        [JsonPropertyName("CODIGO_RECURSO")]
        public string CODIGO_RECURSO { get; set; }
        [JsonPropertyName("CATEGORIA_RECURSO")]
        public string CATEGORIA_RECURSO { get; set; }
        [JsonPropertyName("ESTADO_RECURSO")]
        public string ESTADO_RECURSO { get; set; }
        [JsonPropertyName("DESCRIPCION_RECURSO")]
        public string DESCRIPCION_RECURSO { get; set; }
        
    }
}
