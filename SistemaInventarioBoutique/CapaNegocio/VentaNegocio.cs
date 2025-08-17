using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaNegocio
{
    public class VentaNegocio
    {
        private VentaDatos datos = new VentaDatos();

        public void RegistrarVenta(Venta venta)
        {
            datos.RegistrarVenta(venta);
        }

        public List<Venta> Listar()
        {
            return datos.Listar();
        }
    }
}


