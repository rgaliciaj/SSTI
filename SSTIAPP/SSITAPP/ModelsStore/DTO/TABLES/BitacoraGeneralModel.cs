using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class BitacoraGeneralModel
    {
        [JsonPropertyName("CODIGO_USUARIO")]
        public string CODIGO_USUARIO { get; set; }
        [JsonPropertyName("DESCRIPCION")]
        public string DESCRIPCION {  get; set; }
        [JsonPropertyName("ACCION")]
        public string ACCION { get; set; }
        [JsonPropertyName("FECHA")]
        public DateTime FECHA  { get; set; }
    }
}
