using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Conciertos
    {
        public int Id_Conc { get; set; }
        public string Name_Artista { get; set; }
        public string Lugar_concierto { get; set; }
        public DateTime fecha_concierto { get; set; }
        public string entidades_compra { get; set; }
        public int precio_boleta { get; set; }
        public Organizadores oOrganizador { get; set; }

    }
}
