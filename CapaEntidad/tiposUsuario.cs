using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class tiposUsuario
    {
//        CREATE TABLE Tipos_Usuario(
//  ID_Tipo_Usuario INT PRIMARY KEY identity (1,1) NOT NULL,
//  tipo_usuario VARCHAR(50) NOT NULL
//);

        public int ID_Tipo_Usuario { get; set; }
        public string tipo_usuario { get; set; }
    }
}
