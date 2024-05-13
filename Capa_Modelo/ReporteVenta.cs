using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class ReporteVenta
    {
        public string FechaVenta { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreBoleteria { get; set; }
        public string NITBoleteria { get; set; }
        public string NombreEmpleado { get; set; }
        public string CantidadUnidadesVendidas { get; set; }
        public string CantidadProductos { get; set; }
        public string TotalVenta { get; set; }
    }
}
