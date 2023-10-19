using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class UsuariosModel
    {
        [JsonPropertyName("CODIGO_USUARIO")]
        public string CODIGO_USUARIO {  get; set; }
        [JsonPropertyName("USER_ID")]
        public string USER_ID { get; set; }
        [JsonPropertyName("PASSWORD_USER")]
        public string PASSWORD_USER { get; set;}
        [JsonPropertyName("CORREO")]
        public string CORREO { get; set; }
        [JsonPropertyName("CODIGO_ESTADO")]
        public string CODIGO_ESTADO {  get; set; }
        [JsonPropertyName("TELEFONO_ACTUAL")]
        public string TELEFONO_ACTUAL { get; set; }
        [JsonPropertyName("CODIGO_ROL_USUARIO")]
        public string CODIGO_ROL_USUARIO { get; set; }
        [JsonPropertyName("CODIGO_RUTA")]
        public string CODIGO_RUTA {  get; set; }

    }
}
