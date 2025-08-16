using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class PrendaNegocio
    {
        PrendaDatos datos = new PrendaDatos();

        public List<Prenda> Listar()
        {
            return datos.Listar();
        }

        public void Agregar(Prenda prenda)
        {
            datos.Agregar(prenda);
        }

        public void Actualizar(Prenda prenda)
        {
            datos.Actualizar(prenda);
        }

        public void Eliminar(int idPrenda)
        {
            datos.Eliminar(idPrenda);
        }
    }
}
