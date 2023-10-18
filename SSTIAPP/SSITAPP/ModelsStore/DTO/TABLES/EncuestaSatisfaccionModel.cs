using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class EncuestaSatisfaccionModel
    {
        [JsonPropertyName("CODIGO_ENCUESTA")]
        public string CODIGO_ENCUESTA {  get; set; }
        [JsonPropertyName("CODIGO_TICKET")]
        public string CODIGO_TICKET { get; set; }
        [JsonPropertyName("FECHA_ENCUESTA")]
        public DateTime FECHA_ENCUESTA { get; set; }
        [JsonPropertyName("CODIGO_PUNTUACION")]
        public string CODIGO_PUNTUACION { get; set; }
        [JsonPropertyName("COMENTARIOS")]
        public string COMENTARIOS { get; set; }
    }
}
