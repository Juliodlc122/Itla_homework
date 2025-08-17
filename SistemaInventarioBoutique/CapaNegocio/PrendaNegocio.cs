using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class PrendaNegocio
    {
        PrendaDatos datos = new PrendaDatos();
        public List<Prenda> Listar() => datos.Listar();
        public void Agregar(Prenda p) => datos.Agregar(p);
        public void Actualizar(Prenda p) => datos.Actualizar(p);
        public void Eliminar(int id) => datos.Eliminar(id);
    
        public Prenda ObtenerPorId(int id)
        {
            return datos.ObtenerPorId(id);
        }

    }
}