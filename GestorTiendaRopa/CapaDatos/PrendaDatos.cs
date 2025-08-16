using CapaEntidad;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PrendaDatos
    {
        public List<Prenda> Listar()
        {
            var lista = new List<Prenda>();
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prenda", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Prenda
                    {
                        IdPrenda = (int)reader["IdPrenda"],
                        Nombre = reader["Nombre"].ToString(),
                        IdColor = (int)reader["IdColor"],
                        IdTalla = (int)reader["IdTalla"],
                        Stock = (int)reader["Stock"],
                        Precio = (decimal)reader["Precio"],
                        Temporada = reader["Temporada"].ToString(),
                        Descuento = (float)(double)reader["Descuento"]
                    });
                }
            }
            return lista;
        }

        public void Agregar(Prenda prenda)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand(@"INSERT INTO Prenda 
                                       (Nombre, IdColor, IdTalla, Stock, Precio, Temporada, Descuento) 
                                         VALUES (@Nombre, @IdColor, @IdTalla, @Stock, @Precio, @Temporada, @Descuento)",
                                         con);
                cmd.Parameters.AddWithValue("@Nombre", prenda.Nombre);
                cmd.Parameters.AddWithValue("@IdColor", prenda.IdColor);
                cmd.Parameters.AddWithValue("@IdTalla", prenda.IdTalla);
                cmd.Parameters.AddWithValue("@Stock", prenda.Stock);
                cmd.Parameters.AddWithValue("@Precio", prenda.Precio);
                cmd.Parameters.AddWithValue("@Temporada", prenda.Temporada);
                cmd.Parameters.AddWithValue("@Descuento", prenda.Descuento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Prenda prenda)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand(@"UPDATE Prenda SET 
                    Nombre = @Nombre,
                    IdColor = @IdColor,
                    IdTalla = @IdTalla,
                    Stock = @Stock,
                    Precio = @Precio,
                    Temporada = @Temporada,
                    Descuento = @Descuento
                    WHERE IdPrenda = @IdPrenda", con);
                cmd.Parameters.AddWithValue("@Nombre", prenda.Nombre);
                cmd.Parameters.AddWithValue("@IdColor", prenda.IdColor);
                cmd.Parameters.AddWithValue("@IdTalla", prenda.IdTalla);
                cmd.Parameters.AddWithValue("@Stock", prenda.Stock);
                cmd.Parameters.AddWithValue("@Precio", prenda.Precio);
                cmd.Parameters.AddWithValue("@Temporada", prenda.Temporada);
                cmd.Parameters.AddWithValue("@Descuento", prenda.Descuento);
                cmd.Parameters.AddWithValue("@IdPrenda", prenda.IdPrenda);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idPrenda)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Prenda WHERE IdPrenda = @IdPrenda", con);
                cmd.Parameters.AddWithValue("@IdPrenda", idPrenda);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
