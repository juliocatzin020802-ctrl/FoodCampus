using Dapper;
using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;
using FoodCampus.Infrastructure.Persistence.Mappers;
using FoodCampus.Infrastructure.Persistence.Models;
using Microsoft.Data.SqlClient;

namespace FoodCampus.Infrastructure.Persistence.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly string _connectionString;

    public RestaurantRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Restaurante>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM dbo.Restaurante";
        var dbModels = await connection.QueryAsync<RestaurantDbModel>(query);
        return dbModels.Select(m => m.ToDomain());
    }

    public async Task<Restaurante?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM dbo.Restaurante WHERE Id = @Id";
        var dbModel = await connection.QueryFirstOrDefaultAsync<RestaurantDbModel>(query, new { Id = id });
        return dbModel?.ToDomain();
    }

    public async Task<int> CreateAsync(Restaurante restaurante)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"INSERT INTO dbo.Restaurante (Nombre, Especialidad, HorarioApertura, HorarioCierre) 
                      VALUES (@Nombre, @Especialidad, @HorarioApertura, @HorarioCierre);
                      SELECT CAST(SCOPE_IDENTITY() as int);";
        var dbModel = restaurante.ToDbModel();
        return await connection.ExecuteScalarAsync<int>(query, dbModel);
    }
}
