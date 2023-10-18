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
        [JsonPropertyName("CODIGO_EMPLEADO_ASIGNADO")]
        public string CODIGO_EMPLEADO_ASIGNADO {  get; set; }
        [JsonPropertyName("CATEGORIA_RECURSO")]
        public string CATEGORIA_RECURSO { get; set; }
        [JsonPropertyName("ESTADO_RECURSO")]
        public string ESTADO_RECURSO { get; set; }
        [JsonPropertyName("DESCRIPCION_RECURSO")]
        public string DESCRIPCION_RECURSO { get; set; }
        [JsonPropertyName("MARCA_RECURSO")]
        public string MARCA_RECURSO { get; set; }
        [JsonPropertyName("MODELO_RECURSO")]
        public string MODELO_RECURSO { get; set; }
        [JsonPropertyName("FECHA_ADQUISICION")] 
        public DateTime FECHA_ADQUISICION {  get; set; }
        [JsonPropertyName("FECHA_INACTIVO")]
        public DateTime FECHA_INACTIVO { get; set; }
    }
}
