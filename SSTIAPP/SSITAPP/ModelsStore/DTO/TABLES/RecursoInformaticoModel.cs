using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class RecursoInformaticoModel
    {
        public string CODIGO_RECURSO { get; set; }
        public string CODIGO_EMPLEADO_ASIGNADO {  get; set; }
        public string CATEGORIA_RECURSO { get; set; }
        public string ESTADO_RECURSO { get; set; }
        public string DESCRIPCION_RECURSO { get; set; }
        public string MARCA_RECURSO { get; set; }
        public string MODELO_RECURSO { get; set; }
        public DateTime FECHA_ADQUISICION {  get; set; }
        public DateTime FECHA_INACTIVO { get; set; }
    }
}
