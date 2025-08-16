using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class VentaNegocio
    {
        VentaDatos datos = new VentaDatos();

        public List<Venta> Listar()
        {
            return datos.Listar();
        }

        public void Agregar(Venta venta)
        {
            datos.Agregar(venta);
        }
    }
}
