using ModelsStore.DTO.TABLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.PARAM
{
    public class LOGIN
    {
        [JsonPropertyName("USUARIO")]
        public string USUARIO { get; set; }
        [JsonPropertyName("PASSWORD")]
        public string PASSWORD { get; set;}
    }
}
