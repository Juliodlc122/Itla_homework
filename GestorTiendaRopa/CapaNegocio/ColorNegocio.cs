using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class ColorNegocio
    {
        ColorDatos datos = new ColorDatos();

        public List<Color> Listar()
        {
            return datos.Listar();
        }

        public void Agregar(Color color)
        {
            datos.Agregar(color);
        }
    }
}
