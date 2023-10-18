using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class TicketModel
    {
        public string CODIGO_TICKET { get; set; }
        public string CODIGO_EMPLEADO_ASIGNADO {  get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO_TICKET { get; set; }
        public string CODIGO_PRIORIDAD {  get; set; }
        public DateTime FECHA_HORA_SOLUCION {  get; set; }
        public string CODIGO_EMPLEADO_TECNICO {  get; set; }
        public string CODIGO_RECURSO { get; set; }
    }
}
