using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsStore.DTO.TABLES
{
    public class UsuariosModel
    {
        public string CODIGO_USUARIO {  get; set; }
        public string USER_ID { get; set; }
        public string PASSWORD_USER { get; set;}
        public string CORREO { get; set; }
        public string CODIGO_ESTADO {  get; set; }
        public string TELEFONO_ACTUAL { get; set; }
        public string CODIGO_ROL_USUARIO { get; set; }
    }
}
