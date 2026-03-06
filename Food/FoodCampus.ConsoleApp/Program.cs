using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodCampus.Application.UseCases;
using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;
using FoodCampus.Infrastructure.Persistence;
using FoodCampus.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FoodCampus.ConsoleApp;

class Program
{
    private const string ConnectionString = "Server=test_UTM_JJCP.mssql.somee.com;Database=test_UTM_JJCP;User Id=JulioCat_UTM1;Password=JulioCat8.;TrustServerCertificate=True;";

    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IRestaurantRepository>(new RestaurantRepository(ConnectionString))
            .AddSingleton<IOrderRepository>(new OrderRepository(ConnectionString))
            .AddSingleton(new DatabaseInitializer(ConnectionString))
            .AddTransient<RegisterRestaurant>()
            .AddTransient<ConsultRestaurants>()
            .AddTransient<RegisterOrder>()
            .AddTransient<ConsultOrdersByUser>()
            .BuildServiceProvider();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== FoodCampus - Sistema de Delivery Universitario ===");
            Console.ResetColor();
            Console.WriteLine("0. Inicializar Base de Datos (Crear Tablas)");
            Console.WriteLine("1. Registrar restaurante");
            Console.WriteLine("2. Consultar restaurantes");
            Console.WriteLine("3. Registrar pedido");
            Console.WriteLine("4. Consultar pedidos por usuario");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            var option = Console.ReadLine();

            try
            {
                switch (option)
                {
                    case "0":
                        await InicializarBaseDeDatos(serviceProvider.GetRequiredService<DatabaseInitializer>());
                        break;
                    case "1":
                        await RegistrarRestaurante(serviceProvider.GetRequiredService<RegisterRestaurant>());
                        break;
                    case "2":
                        await ConsultarRestaurantes(serviceProvider.GetRequiredService<ConsultRestaurants>());
                        break;
                    case "3":
                        await RegistrarPedido(
                            serviceProvider.GetRequiredService<RegisterOrder>(),
                            serviceProvider.GetRequiredService<ConsultRestaurants>());
                        break;
                    case "4":
                        await ConsultarPedidos(serviceProvider.GetRequiredService<ConsultOrdersByUser>());
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        MostrarError("Opción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }

            if (!exit)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static async Task InicializarBaseDeDatos(DatabaseInitializer initializer)
    {
        Console.Clear();
        Console.WriteLine("--- Inicializando Base de Datos ---");
        try
        {
            // Subimos un nivel si se ejecuta desde bin/debug o similar, o ajustamos a la ruta absoluta
            string scriptPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Database", "CreateTables.sql");
            
            // Si no existe ahí (por ejemplo, al ejecutar con dotnet run), probamos en la raíz del proyecto
            if (!File.Exists(scriptPath))
            {
                scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Database", "CreateTables.sql");
            }

            // Otra posibilidad: buscarlo en la carpeta padre si estamos en FoodCampus.ConsoleApp
            if (!File.Exists(scriptPath))
            {
                scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "CreateTables.sql");
            }

            Console.WriteLine($"Buscando script en: {Path.GetFullPath(scriptPath)}");
            await initializer.InitializeAsync(scriptPath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTablas creadas exitosamente.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            MostrarError($"Error al inicializar: {ex.Message}");
        }
    }

    static async Task RegistrarRestaurante(RegisterRestaurant useCase)
    {
        Console.Clear();
        Console.WriteLine("--- Registrar Nuevo Restaurante ---");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Especialidad: ");
        string especialidad = Console.ReadLine() ?? "";
        
        Console.Write("Horario Apertura (HH:mm): ");
        if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan apertura)) apertura = new TimeSpan(8, 0, 0);
        
        Console.Write("Horario Cierre (HH:mm): ");
        if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan cierre)) cierre = new TimeSpan(20, 0, 0);

        var restaurante = new Restaurante
        {
            Nombre = nombre,
            Especialidad = especialidad,
            HorarioApertura = apertura,
            HorarioCierre = cierre
        };

        int id = await useCase.ExecuteAsync(restaurante);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nRestaurante registrado con éxito. ID: {id}");
        Console.ResetColor();
    }

    static async Task ConsultarRestaurantes(ConsultRestaurants useCase)
    {
        Console.Clear();
        Console.WriteLine("--- Lista de Restaurantes ---");
        var restaurantes = await useCase.ExecuteAsync();

        if (!restaurantes.Any())
        {
            Console.WriteLine("No hay restaurantes registrados.");
            return;
        }

        foreach (var r in restaurantes)
        {
            Console.WriteLine($"[{r.Id}] {r.Nombre} - {r.Especialidad} ({r.HorarioApertura} - {r.HorarioCierre})");
        }
    }

    static async Task RegistrarPedido(RegisterOrder registerUseCase, ConsultRestaurants consultUseCase)
    {
        Console.Clear();
        await ConsultarRestaurantes(consultUseCase);
        
        Console.Write("\nSeleccione el ID del restaurante: ");
        if (!int.TryParse(Console.ReadLine(), out int idRestaurante))
        {
            MostrarError("ID de restaurante no válido.");
            return;
        }

        Console.Write("Ingrese ID de Usuario: ");
        if (!int.TryParse(Console.ReadLine(), out int idUsuario))
        {
            MostrarError("ID de usuario no válido.");
            return;
        }
        
        Console.Write("Costo de Envío: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal costoEnvio))
        {
            MostrarError("Costo de envío no válido.");
            return;
        }

        var pedido = new Pedido
        {
            IdRestaurante = idRestaurante,
            IdUsuario = idUsuario,
            CostoEnvio = costoEnvio,
            FechaHora = DateTime.Now
        };

        Console.WriteLine("\n--- Agregar Platillos ---");
        bool agregarMas = true;
        while (agregarMas)
        {
            Console.Write("ID Platillo: ");
            if (!int.TryParse(Console.ReadLine(), out int idPlatillo)) break;

            Console.Write("Cantidad: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad)) break;

            Console.Write("Subtotal: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal subtotal)) break;

            pedido.Detalles.Add(new DetallePedido
            {
                IdPlatillo = idPlatillo,
                Cantidad = cantidad,
                Subtotal = subtotal
            });

            Console.Write("¿Agregar otro platillo? (s/n): ");
            agregarMas = Console.ReadLine()?.ToLower() == "s";
        }

        if (!pedido.Detalles.Any())
        {
            MostrarError("No se puede registrar un pedido sin platillos.");
            return;
        }

        int idPedido = await registerUseCase.ExecuteAsync(pedido);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nPedido registrado con éxito. ID Pedido: {idPedido}");
        Console.ResetColor();
    }

    static async Task ConsultarPedidos(ConsultOrdersByUser useCase)
    {
        Console.Clear();
        Console.Write("Ingrese ID de Usuario para consultar: ");
        if (!int.TryParse(Console.ReadLine(), out int userId))
        {
            MostrarError("ID no válido.");
            return;
        }

        var pedidos = await useCase.ExecuteAsync(userId);
        Console.WriteLine($"\n--- Pedidos del Usuario {userId} ---");
        foreach (var p in pedidos)
        {
            Console.WriteLine($"ID Pedido: {p.IdPedido} | Restaurante: {p.IdRestaurante} | Fecha: {p.FechaHora} | Envío: ${p.CostoEnvio}");
        }
    }

    static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nERROR: {mensaje}");
        Console.ResetColor();
    }
}
