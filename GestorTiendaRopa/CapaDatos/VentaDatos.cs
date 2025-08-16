using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class VentaDatos
    {
        public List<Venta> Listar()
        {
            var lista = new List<Venta>();
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Venta", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Venta
                    {
                        IdVenta = (int)reader["IdVenta"],
                        IdPrenda = (int)reader["IdPrenda"],
                        Cantidad = (int)reader["Cantidad"],
                        Fecha = (string)reader["Fecha"],
                        Total = (decimal)reader["Total"]
                    });
                }
            }
            return lista;
        }

        public void Agregar(Venta venta)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                var cmd = new SqlCommand(@"INSERT INTO Venta 
                                   (IdPrenda, Cantidad, Fecha, Total) 
                                   VALUES (@IdPrenda, @Cantidad, @Fecha, @Total)", con);
                cmd.Parameters.AddWithValue("@IdPrenda", venta.IdPrenda);
                cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@Total", venta.Total);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
