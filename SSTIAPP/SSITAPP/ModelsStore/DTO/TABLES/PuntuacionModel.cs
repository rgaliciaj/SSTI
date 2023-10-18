using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class PuntuacionModel
    {
        [JsonPropertyName("CODIGO_PUNTUACION")]
        public string CODIGO_PUNTUACION {  get; set; }
        [JsonPropertyName("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [JsonPropertyName("VALOR")]
        public string VALOR { get; set; }
    }
}
