using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class ColorNegocio
    {
        ColorDatos datos = new ColorDatos();

        public List<Color> Listar() => datos.Listar();

        public void Agregar(Color c) => datos.Agregar(c);

        public void Actualizar(Color c) => datos.Actualizar(c);

        public void Eliminar(int id) => datos.Eliminar(id);
    }
}
