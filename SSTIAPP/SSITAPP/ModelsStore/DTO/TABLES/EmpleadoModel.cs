using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class EmpleadoModel
    {
        public string CODIGO_EMPLEADO { get; set; }
        public string NOMBRE {  get; set; }
        public string NIT_CLIENTE { get; set; }
        public string DIRECCION_CLIENTE { get; set; }
        public string COD_DEPTO_AREA { get; set; }
        public string CODIGO_ESTADO { get; set; }
        public string CODIGO_ROL_USUARIO {  get; set; }
    }
}
