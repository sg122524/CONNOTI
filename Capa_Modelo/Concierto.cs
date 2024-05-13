using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo
{
    public class Concierto
    {
        public int IdConcierto { get; set; }
        public string Codigo { get; set; }
        public int ValorCodigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdGenero { get; set; }
        public Genero oGenero { get; set; }
        public bool Activo { get; set; }
    }
}
