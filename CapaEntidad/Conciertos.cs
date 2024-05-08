using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class conciertos
    {
//        CREATE TABLE Conciertos(
//  ID_Concierto INT PRIMARY KEY identity(1,1) NOT NULL,
//  ID_Artista INT NOT NULL,
//  ID_Lugar INT NOT NULL,
//  fecha_concierto DATE NOT NULL,
//  entidades_compra VARCHAR(50),
//  precio_boleta INT NOT NULL
//);

        public int ID_Concierto { get; set; }
        public artistas oartistas { get; set; }
        public lugar olugar { get; set; }
        public DateTime fecha_concierto { get; set; }
        public string entidades_compra { get; set; }
        public int precio_boleta { get; set; }
    }
}
