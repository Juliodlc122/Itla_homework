using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class TallaNegocio
    {
        TallaDatos datos = new TallaDatos();

        public List<Talla> Listar()
        {
            return datos.Listar();
        }

        public void Agregar(Talla talla)
        {
            datos.Agregar(talla);
        }
    }
}
