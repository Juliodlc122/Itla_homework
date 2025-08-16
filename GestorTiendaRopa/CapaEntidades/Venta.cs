using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdPrenda { get; set; }
        public int Cantidad { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
