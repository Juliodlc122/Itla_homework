using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Prenda
    {
        public int IdPrenda { get; set; }
        public string Nombre { get; set; }
        public int IdColor { get; set; }
        public int IdTalla { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public string Temporada { get; set; }
        public float Descuento { get; set; } // % de descuento aplicado
    }
}