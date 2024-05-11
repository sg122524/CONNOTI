using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class ConciertoProveedor
    {
        public int IdConciertoProveedor { get; set; }
        public Concierto oConcierto { get; set; }
        public Proveedor oProveedor { get; set; }
        public int Stock { get; set; }
        public decimal PrecioComun { get; set; }
        public decimal PrecioVIP { get; set; }
        public bool Iniciado { get; set; }

        public bool Activo { get; set;}
        public DateTime FechaRegistro { get; set; }
    }
}
