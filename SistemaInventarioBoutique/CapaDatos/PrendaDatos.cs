using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PrendaDatos
    {
        public List<Prenda> Listar()
        {
            var lista = new List<Prenda>();
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Prenda", con);
                var reader = cmd.ExecuteReader();
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

        public void Agregar(Prenda p)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("INSERT INTO Prenda (Nombre, IdColor, IdTalla, Stock, Precio, Temporada, Descuento) VALUES (@Nombre, @IdColor, @IdTalla, @Stock, @Precio, @Temporada, @Descuento)", con);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@IdColor", p.IdColor);
                cmd.Parameters.AddWithValue("@IdTalla", p.IdTalla);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Temporada", p.Temporada);
                cmd.Parameters.AddWithValue("@Descuento", p.Descuento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Prenda p)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE Prenda SET Nombre=@Nombre, IdColor=@IdColor, IdTalla=@IdTalla, Stock=@Stock, Precio=@Precio, Temporada=@Temporada, Descuento=@Descuento WHERE IdPrenda=@IdPrenda", con);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@IdColor", p.IdColor);
                cmd.Parameters.AddWithValue("@IdTalla", p.IdTalla);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Temporada", p.Temporada);
                cmd.Parameters.AddWithValue("@Descuento", p.Descuento);
                cmd.Parameters.AddWithValue("@IdPrenda", p.IdPrenda);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Prenda WHERE IdPrenda=@IdPrenda", con);
                cmd.Parameters.AddWithValue("@IdPrenda", id);
                cmd.ExecuteNonQuery();
            }
        }
        public Prenda ObtenerPorId(int id)
        {
            Prenda prenda = null;

            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prenda WHERE IdPrenda = @IdPrenda", con);
                cmd.Parameters.AddWithValue("@IdPrenda", id);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prenda = new Prenda
                    {
                        IdPrenda = Convert.ToInt32(dr["IdPrenda"]),
                        Nombre = dr["Nombre"].ToString(),
                        IdColor = Convert.ToInt32(dr["IdColor"]),
                        IdTalla = Convert.ToInt32(dr["IdTalla"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        Temporada = dr["Temporada"].ToString(),
                        Descuento = Convert.ToSingle(dr["Descuento"])
                    };
                }
            }

            return prenda;
        }

    }
}
