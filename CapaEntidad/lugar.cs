using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class lugar
    {
//        CREATE TABLE Lugar(
//  ID_Lugar INT PRIMARY KEY identity(1,1) NOT NULL,
//  nombre_lugar VARCHAR(50) NOT NULL,
//  direccion_lugar VARCHAR(50),
//  aforo_lugar INT,
//  palcos_lugar INT,
//  sillas_lugar INT
//);

        public int ID_Lugar { get; set; }
        public string nombre_lugar { get; set; }
        public string direccion_lugar { get; set; }
        public int aforo_lugar { get; set; }
        public int palcos_lugar { get; set; }
        public int sillas_lugar { get; set; }
    }
}
