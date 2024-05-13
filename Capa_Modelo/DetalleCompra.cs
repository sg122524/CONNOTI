using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public Concierto oConcierto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitarioComun { get; set; }
        public string TextoPrecioUnitarioComun { get; set; }
        public decimal PrecioUnitarioVIP { get; set; }
        public string TextoPrecioUnitarioVIP { get; set; }
        public decimal TotalCosto { get; set; }
        public string TextoTotalCosto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
