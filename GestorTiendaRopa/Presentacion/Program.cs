using System;
using CapaNegocio;
using CapaEntidad;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        PrendaNegocio prendaNegocio = new PrendaNegocio();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Gestor Tienda de Ropa ===");
            Console.WriteLine("1. Mostrar prendas");
            Console.WriteLine("2. Agregar prendas");
            Console.WriteLine("3. Actualizar prendas");
            Console.WriteLine("4. Eliminar prenda");
            Console.WriteLine("5. Salir");
            Console.Write("Elija una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarPrendas(prendaNegocio);
                    break;
                case "2":
                    AgregarPrenda(prendaNegocio);
                    break;
                case "3":
                    ActualizarPrenda(prendaNegocio);
                    break;
                case "4":
                    EliminarPrenda(prendaNegocio);
                    break;
                case "5":
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

    static void AgregarPrenda(PrendaNegocio prendaNegocio)
    {
        Prenda nueva = new Prenda();
        Console.Write("Nombre: ");
        nueva.Nombre = Console.ReadLine();
        Console.Write("IdColor: ");
        nueva.IdColor = int.Parse(Console.ReadLine());
        Console.Write("IdTalla: ");
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

    static void ActualizarPrenda(PrendaNegocio prendaNegocio)
    {
        Console.Write("ID de la prenda a actualizar: ");
        int id = int.Parse(Console.ReadLine());

        Prenda prenda = new Prenda { IdPrenda = id };
        Console.Write("Nuevo nombre: ");
        prenda.Nombre = Console.ReadLine();
        Console.Write("Nuevo IdColor: ");
        prenda.IdColor = int.Parse(Console.ReadLine());
        Console.Write("Nuevo IdTalla: ");
        prenda.IdTalla = int.Parse(Console.ReadLine());
        Console.Write("Nuevo Stock: ");
        prenda.Stock = int.Parse(Console.ReadLine());
        Console.Write("Nuevo Precio: ");
        prenda.Precio = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Nueva Temporada: ");
        prenda.Temporada = Console.ReadLine();
        Console.Write("Nuevo descuento (%): ");
        prenda.Descuento = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        prendaNegocio.Actualizar(prenda);
        Console.WriteLine("Prenda actualizada.");
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
}
