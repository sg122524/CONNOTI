using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class generos
    {
//        CREATE TABLE Generos(
//  ID_Genero INT PRIMARY KEY identity(1,1) NOT NULL,
//  nombre_genero VARCHAR(50) NOT NULL
//);

        public int ID_Genero { get; set; }
        public string nombre_genero { get; set; }
    }
}
