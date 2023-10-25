using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.Models
{
    public class Respuesta
    {
        [JsonPropertyName("codigo")]
        public string codigo {  get; set; }
        [JsonPropertyName("mensaje")]
        public string mensaje { get; set; }
        [JsonPropertyName("resultado")]
        public object resultado { get; set; }
    }
}
