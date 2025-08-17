using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class VentaDatos
{
    private string conexion = "Server=JULIO\\SQLEXPRESS;Database=TiendaRopa;Trusted_Connection=True;";

    public void RegistrarVenta(Venta venta)
    {
        using (SqlConnection conn = new SqlConnection(conexion))
        {
            conn.Open();

            string query = "INSERT INTO Venta (IdPrenda, Cantidad, Total, Fecha) VALUES (@IdPrenda, @Cantidad, @Total, @Fecha)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdPrenda", venta.IdPrenda);
                cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                cmd.Parameters.AddWithValue("@Total", venta.Total);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now); 

                cmd.ExecuteNonQuery();
            }

            // Actualizar stock
            string updateStock = "UPDATE Prenda SET Stock = Stock - @Cantidad WHERE IdPrenda = @IdPrenda";
            using (SqlCommand cmdStock = new SqlCommand(updateStock, conn))
            {
                cmdStock.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                cmdStock.Parameters.AddWithValue("@IdPrenda", venta.IdPrenda);
                cmdStock.ExecuteNonQuery();
            }
        }
    }

    public List<Venta> Listar()
    {
        List<Venta> lista = new List<Venta>();
        using (SqlConnection conn = new SqlConnection(conexion))
        {
            conn.Open();
            string query = "SELECT IdVenta, IdPrenda, Cantidad, Total FROM Venta";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Venta
                    {
                        IdVenta = (int)dr["IdVenta"],
                        IdPrenda = (int)dr["IdPrenda"],
                        Cantidad = (int)dr["Cantidad"],
                        Total = (decimal)dr["Total"]
                    });
                }
            }
        }
        return lista;
    }
}


