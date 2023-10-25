using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.Models
{
    public class AuthRequest
    {
        [JsonPropertyName("Usuario")]
        public string Usuario { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
