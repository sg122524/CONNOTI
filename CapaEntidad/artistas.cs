using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class artistas
    {
//        CREATE TABLE Artistas(
//  ID_Artista INT PRIMARY KEY identity(1,1) NOT NULL,
//  nombre_artista VARCHAR(50) NOT NULL,
//  biografia VARCHAR(100),
//  correo_contacto VARCHAR(50),
//  redes_sociales VARCHAR(100)
//);

        public int ID_Artista { get; set; }
        public string nombre_artista { get; set; }
        public string biografia { get; set; }
        public string correo_contacto { get; set; }
        public string redes_sociales { get; set; }

        public generos ogeneros { get; set; }
    }
}
