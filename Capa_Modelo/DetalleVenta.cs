using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class DetalleVenta
    {
        public int Cantidad { get; set; }
        public string NombreConcierto { get; set; }
        public float PrecioUnidad { get; set; }
        public string TextoPrecioUnidad { get; set; }
        public float ImporteTotal { get; set; }
        public string TextoImporteTotal { get; set; }

    }
}
