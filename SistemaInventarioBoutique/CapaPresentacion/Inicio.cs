using System;
using CapaNegocio;
using CapaEntidad;
using System.Globalization;

// Julio Ruiz Matricula:2024-2009
class Program
{
    static void Main(string[] args)
    {
        PrendaNegocio prendaNegocio = new PrendaNegocio();
        ColorNegocio colorNegocio = new ColorNegocio();
        TallaNegocio tallaNegocio = new TallaNegocio();
        VentaNegocio ventaNegocio = new VentaNegocio();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Gestor Tienda de Ropa ===");
            Console.WriteLine("1. Mostrar todas las prendas");
            Console.WriteLine("2. Agregar prenda");
            Console.WriteLine("3. Actualizar prenda");
            Console.WriteLine("4. Eliminar prenda");
            Console.WriteLine("5. Ver prenda por ID");
            Console.WriteLine("6. Registrar venta");
            Console.WriteLine("7. Ver ventas realizadas");
            Console.WriteLine("8. Salir");
            Console.Write("Elija una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarPrendas(prendaNegocio);
                    break;
                case "2":
                    AgregarPrenda(prendaNegocio, colorNegocio, tallaNegocio);
                    break;
                case "3":
                    ActualizarPrenda(prendaNegocio, colorNegocio, tallaNegocio);
                    break;
                case "4":
                    EliminarPrenda(prendaNegocio);
                    break;
                case "5":
                    VerPrendaPorId(prendaNegocio);
                    break;
                case "6":
                    RegistrarVenta(prendaNegocio, ventaNegocio);
                    break;
                case "7":
                    ListarVentas(ventaNegocio, prendaNegocio);
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Opción inválida");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ListarPrendas(PrendaNegocio prendaNegocio)
    {
        var lista = prendaNegocio.Listar();
        Console.WriteLine("---- Prendas ----");
        foreach (var p in lista)
        {
            decimal precioConDescuento = p.Precio - (p.Precio * (decimal)p.Descuento / 100m);
            Console.WriteLine($"{p.IdPrenda}: {p.Nombre} | Stock: {p.Stock} | Precio: ${p.Precio:F2} | Temporada: {p.Temporada} | Descuento: {p.Descuento}% | Precio final: ${precioConDescuento:F2}");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void AgregarPrenda(PrendaNegocio prendaNegocio, ColorNegocio colorNegocio, TallaNegocio tallaNegocio)
    {
        Prenda nueva = new Prenda();
        Console.Write("Nombre: ");
        nueva.Nombre = Console.ReadLine();

        Console.WriteLine("---- Colores disponibles ----");
        foreach (var c in colorNegocio.Listar())
        {
            Console.WriteLine($"{c.IdColor}: {c.Nombre}");
        }
        Console.Write("Seleccione IdColor: ");
        nueva.IdColor = int.Parse(Console.ReadLine());

        Console.WriteLine("---- Tallas disponibles ----");
        foreach (var t in tallaNegocio.Listar())
        {
            Console.WriteLine($"{t.IdTalla}: {t.Nombre}");
        }
        Console.Write("Seleccione IdTalla: ");
        nueva.IdTalla = int.Parse(Console.ReadLine());

        Console.Write("Stock: ");
        nueva.Stock = int.Parse(Console.ReadLine());
        Console.Write("Precio: ");
        nueva.Precio = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Temporada: ");
        nueva.Temporada = Console.ReadLine();
        Console.Write("Descuento (%): ");
        nueva.Descuento = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        prendaNegocio.Agregar(nueva);
        Console.WriteLine("Prenda agregada con éxito.");
        Console.ReadKey();
    }

    static void ActualizarPrenda(PrendaNegocio prendaNegocio, ColorNegocio colorNegocio, TallaNegocio tallaNegocio)
    {
        Console.Write("ID de la prenda a actualizar: ");
        int id = int.Parse(Console.ReadLine());

        var prendaExistente = prendaNegocio.ObtenerPorId(id);

        if (prendaExistente == null)
        {
            Console.WriteLine("No se encontró la prenda con ese ID.");
            Console.ReadKey();
            return;
        }

        decimal precioConDescuento = prendaExistente.Precio - (prendaExistente.Precio * (decimal)prendaExistente.Descuento / 100m);
        Console.WriteLine("\n--- Datos actuales de la prenda ---");
        Console.WriteLine($"ID: {prendaExistente.IdPrenda}");
        Console.WriteLine($"Nombre: {prendaExistente.Nombre}");
        Console.WriteLine($"Stock: {prendaExistente.Stock}");
        Console.WriteLine($"Precio: ${prendaExistente.Precio:F2}");
        Console.WriteLine($"Temporada: {prendaExistente.Temporada}");
        Console.WriteLine($"Descuento: {prendaExistente.Descuento}%");
        Console.WriteLine($"Precio final: ${precioConDescuento:F2}");
        Console.WriteLine("-----------------------------------\n");

        Prenda prenda = new Prenda { IdPrenda = id };

        Console.Write("Nuevo nombre (dejar vacío para mantener): ");
        string nombre = Console.ReadLine();
        prenda.Nombre = string.IsNullOrEmpty(nombre) ? prendaExistente.Nombre : nombre;

        Console.WriteLine("---- Colores disponibles ----");
        foreach (var c in colorNegocio.Listar())
        {
            Console.WriteLine($"{c.IdColor}: {c.Nombre}");
        }
        Console.Write($"Seleccione nuevo IdColor (actual {prendaExistente.IdColor}): ");
        string idColorInput = Console.ReadLine();
        prenda.IdColor = string.IsNullOrEmpty(idColorInput) ? prendaExistente.IdColor : int.Parse(idColorInput);

        Console.WriteLine("---- Tallas disponibles ----");
        foreach (var t in tallaNegocio.Listar())
        {
            Console.WriteLine($"{t.IdTalla}: {t.Nombre}");
        }
        Console.Write($"Seleccione nuevo IdTalla (actual {prendaExistente.IdTalla}): ");
        string idTallaInput = Console.ReadLine();
        prenda.IdTalla = string.IsNullOrEmpty(idTallaInput) ? prendaExistente.IdTalla : int.Parse(idTallaInput);

        Console.Write($"Nuevo Stock (actual {prendaExistente.Stock}): ");
        string stockInput = Console.ReadLine();
        prenda.Stock = string.IsNullOrEmpty(stockInput) ? prendaExistente.Stock : int.Parse(stockInput);

        Console.Write($"Nuevo Precio (actual {prendaExistente.Precio:F2}): ");
        string precioInput = Console.ReadLine();
        prenda.Precio = string.IsNullOrEmpty(precioInput) ? prendaExistente.Precio : decimal.Parse(precioInput, CultureInfo.InvariantCulture);

        Console.Write($"Nueva Temporada (actual {prendaExistente.Temporada}): ");
        string temporada = Console.ReadLine();
        prenda.Temporada = string.IsNullOrEmpty(temporada) ? prendaExistente.Temporada : temporada;

        Console.Write($"Nuevo Descuento % (actual {prendaExistente.Descuento}): ");
        string descuentoInput = Console.ReadLine();
        prenda.Descuento = string.IsNullOrEmpty(descuentoInput) ? prendaExistente.Descuento : float.Parse(descuentoInput, CultureInfo.InvariantCulture);

        prendaNegocio.Actualizar(prenda);
        Console.WriteLine("Prenda actualizada con éxito.");
        Console.ReadKey();
    }

    static void EliminarPrenda(PrendaNegocio prendaNegocio)
    {
        Console.Write("ID de la prenda a eliminar: ");
        int id = int.Parse(Console.ReadLine());
        prendaNegocio.Eliminar(id);
        Console.WriteLine("Prenda eliminada.");
        Console.ReadKey();
    }

    static void VerPrendaPorId(PrendaNegocio prendaNegocio)
    {
        Console.Write("Ingrese el ID de la prenda: ");
        int id = int.Parse(Console.ReadLine());

        var prenda = prendaNegocio.ObtenerPorId(id);
        if (prenda != null)
        {
            decimal precioConDescuento = prenda.Precio - (prenda.Precio * (decimal)prenda.Descuento / 100m);
            Console.WriteLine($"ID: {prenda.IdPrenda}\nNombre: {prenda.Nombre}\nStock: {prenda.Stock}\nPrecio: ${prenda.Precio:F2}\nTemporada: {prenda.Temporada}\nDescuento: {prenda.Descuento}%\nPrecio Final: ${precioConDescuento:F2}");
        }
        else
        {
            Console.WriteLine("No se encontró la prenda con ese ID.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void RegistrarVenta(PrendaNegocio prendaNegocio, VentaNegocio ventaNegocio)
    {
        Console.Write("Ingrese el ID de la prenda a vender: ");
        int id = int.Parse(Console.ReadLine());

        var prenda = prendaNegocio.ObtenerPorId(id);

        if (prenda == null)
        {
            Console.WriteLine("No se encontró la prenda.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Prenda: {prenda.Nombre} | Stock disponible: {prenda.Stock}");
        Console.Write("Cantidad a vender: ");
        int cantidad = int.Parse(Console.ReadLine());

        if (cantidad > prenda.Stock)
        {
            Console.WriteLine("No hay suficiente stock.");
            Console.ReadKey();
            return;
        }

        decimal precioFinal = prenda.Precio - (prenda.Precio * (decimal)prenda.Descuento / 100m);
        decimal total = precioFinal * cantidad;

        prenda.Stock -= cantidad;
        prendaNegocio.Actualizar(prenda);

        Venta venta = new Venta
        {
            
            IdPrenda = prenda.IdPrenda,
            Cantidad = cantidad,
            Total = total
            // La fecha la maneja la base de datos
        };

        ventaNegocio.RegistrarVenta(venta);

        Console.WriteLine($"Venta realizada con éxito. Total a pagar: ${total:F2}");
        Console.ReadKey();
    }


    static void ListarVentas(VentaNegocio ventaNegocio, PrendaNegocio prendaNegocio)
    {
        var lista = ventaNegocio.Listar();
        Console.WriteLine("---- Ventas Realizadas ----");
        foreach (var v in lista)
        {
            var prenda = prendaNegocio.ObtenerPorId(v.IdPrenda);
            string nombrePrenda = prenda != null ? prenda.Nombre : "Desconocida";

            Console.WriteLine($"ID: {v.IdVenta} | Prenda: {nombrePrenda} | Cantidad: {v.Cantidad} | Total: ${v.Total:F2}");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

}
