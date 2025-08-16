using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class TallaDatos
    {
        public List<Talla> Listar()
        {
            var lista = new List<Talla>();
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Talla", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Talla
                    {
                        IdTalla = (int)reader["IdTalla"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Agregar(Talla talla)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO Talla (Nombre) VALUES (@Nombre)", con);
                cmd.Parameters.AddWithValue("@Nombre", talla.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Talla talla)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE Talla SET Nombre = @Nombre WHERE IdTalla = @IdTalla", con);
                cmd.Parameters.AddWithValue("@Nombre", talla.Nombre);
                cmd.Parameters.AddWithValue("@IdTalla", talla.IdTalla);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idTalla)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Talla WHERE IdTalla = @IdTalla", con);
                cmd.Parameters.AddWithValue("@IdTalla", idTalla);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
