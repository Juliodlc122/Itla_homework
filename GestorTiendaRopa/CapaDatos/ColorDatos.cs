using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class ColorDatos
    {
        public List<Color> Listar()
        {
            var lista = new List<Color>();
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Color", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Color
                    {
                        IdColor = (int)reader["IdColor"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Agregar(Color color)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO Color (Nombre) VALUES (@Nombre)", con);
                cmd.Parameters.AddWithValue("@Nombre", color.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Color color)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE Color SET Nombre = @Nombre WHERE IdColor = @IdColor", con);
                cmd.Parameters.AddWithValue("@Nombre", color.Nombre);
                cmd.Parameters.AddWithValue("@IdColor", color.IdColor);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idColor)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Color WHERE IdColor = @IdColor", con);
                cmd.Parameters.AddWithValue("@IdColor", idColor);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
