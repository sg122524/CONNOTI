using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public Venta oVenta { get; set; }
        public Concierto oConcierto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioComun { get; set; }
        public decimal ImporteTotal { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        
    }
}
