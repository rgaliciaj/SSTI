using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class RolUsuarioModel
    {
        [JsonPropertyName("CODIGO_ROL_USUARIO")]
        public string CODIGO_ROL_USUARIO { get; set; }
        [JsonPropertyName("NOMBRE_ROL")]
        public string NOMBRE_ROL { get; set; }
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO { get; set; }
    }
}
