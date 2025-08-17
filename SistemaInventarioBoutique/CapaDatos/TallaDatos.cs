using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class TallaDatos
    {
        public List<Talla> Listar()
        {
            List<Talla> lista = new List<Talla>();
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TALLA", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Talla
                    {
                        IdTalla = Convert.ToInt32(dr["IdTalla"]),
                        Nombre = dr["Nombre"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Agregar(Talla t)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TALLA (Nombre) VALUES (@Nombre)", con);
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Talla t)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TALLA SET Nombre=@Nombre WHERE IdTalla=@IdTalla", con);
                cmd.Parameters.AddWithValue("@IdTalla", t.IdTalla);
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM TALLA WHERE IdTalla=@IdTalla", con);
                cmd.Parameters.AddWithValue("@IdTalla", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
