using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class TipoCategoriaModel
    {
        [JsonPropertyName("CODIGO_TIPO_CATEGORIA")]
        public string CODIGO_TIPO_CATEGORIA { get; set;}
        [JsonPropertyName("NOMBRE_TIPO_CATEGORIA")]
        public string NOMBRE_TIPO_CATEGORIA { get; set;}
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO {  get; set;}
    }
}
