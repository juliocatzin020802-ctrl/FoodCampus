using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace FoodCampus.Infrastructure.Persistence;

public class DatabaseInitializer
{
    private readonly string _connectionString;

    public DatabaseInitializer(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task InitializeAsync(string scriptPath)
    {
        if (!File.Exists(scriptPath))
        {
            throw new FileNotFoundException($"No se encontró el archivo de script en: {scriptPath}");
        }

        string script = await File.ReadAllTextAsync(scriptPath);

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        // SQL Server no permite ejecutar scripts con múltiples CREATE TABLE en un solo comando de Dapper si hay GO u otros separadores.
        // Dividimos por lotes si es necesario, o lo ejecutamos como un bloque único si el script es compatible.
        await connection.ExecuteAsync(script);
    }
}
