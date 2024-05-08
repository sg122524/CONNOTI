using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class usuarios
    {


        public int ID_Usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string correo_usuario { get; set; }
        public string contrasena { get; set; }
        public int tipo_usuario { get; set; } 
        public string celular_usuario { get; set; }
        public string num_NIT { get; set; } 
        public bool reestablecer { get; set; }

        // Agregar una propiedad para el tipo de usuario
        
        public tiposUsuario otiposUsuario { get; set; }
        

    }
}
