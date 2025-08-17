using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TallaNegocio
    {
        TallaDatos datos = new TallaDatos();
        public List<Talla> Listar() => datos.Listar();
        public void Agregar(Talla t) => datos.Agregar(t);
        public void Actualizar(Talla t) => datos.Actualizar(t);
        public void Eliminar(int id) => datos.Eliminar(id);
    }
}
