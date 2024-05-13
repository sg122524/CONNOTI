using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class ConciertoBoleteria
    {
        public int IdConciertoBoleteriaa { get; set; }
        public Concierto oConcierto { get; set; }
        public BOLETERIAS oBoleteria { get; set; }
        public int Stock { get; set; }
        public decimal PrecioComun { get; set; }
        public decimal PrecioVIP { get; set; }
        public bool Iniciado { get; set; }
    }
}
