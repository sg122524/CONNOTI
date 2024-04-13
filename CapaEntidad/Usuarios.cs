using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        public int Id_User { get; set; }
        public string name_user { get; set; }
        public string Last_nameUser { get; set; }
        public string email_user { get; set; }
        public string username { get; set; }
        public string passw { get; set; }
        public bool reestablecer { get; set; }
        public bool activo { get; set; }

       // public tipos_Usuario TipoU { get; set; }
    }
}
