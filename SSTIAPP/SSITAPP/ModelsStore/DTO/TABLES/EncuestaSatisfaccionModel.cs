using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class EncuestaSatisfaccionModel
    {
        public string CODIGO_ENCUESTA {  get; set; }
        public string CODIGO_TICKET { get; set; }
        public DateTime FECHA_ENCUESTA { get; set; }
        public string CODIGO_PUNTUACION { get; set; }
        public string COMENTARIOS { get; set; }
    }
}
