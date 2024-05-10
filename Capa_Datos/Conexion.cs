using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    internal class Conexion
    {
        public static string CN = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
    }
}
