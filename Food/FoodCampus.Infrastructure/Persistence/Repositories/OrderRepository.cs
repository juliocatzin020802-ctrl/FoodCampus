using Dapper;
using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;
using FoodCampus.Infrastructure.Persistence.Mappers;
using FoodCampus.Infrastructure.Persistence.Models;
using Microsoft.Data.SqlClient;

namespace FoodCampus.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly string _connectionString;

    public OrderRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> CreateAsync(Pedido pedido)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        using var transaction = connection.BeginTransaction();

        try
        {
            var orderQuery = @"INSERT INTO dbo.Pedido (IdRestaurante, IdUsuario, FechaHora, CostoEnvio) 
                               VALUES (@IdRestaurante, @IdUsuario, @FechaHora, @CostoEnvio);
                               SELECT CAST(SCOPE_IDENTITY() as int);";
            
            var orderDbModel = pedido.ToDbModel();
            var orderId = await connection.ExecuteScalarAsync<int>(orderQuery, orderDbModel, transaction);
            
            foreach (var detail in pedido.Detalles)
            {
                detail.IdPedido = orderId;
                var detailQuery = @"INSERT INTO dbo.DetallePedido (IdPedido, IdPlatillo, Cantidad, Subtotal) 
                                    VALUES (@IdPedido, @IdPlatillo, @Cantidad, @Subtotal)";
                var detailDbModel = detail.ToDbModel();
                await connection.ExecuteAsync(detailQuery, detailDbModel, transaction);
            }

            await transaction.CommitAsync();
            return orderId;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<Pedido>> GetByUserIdAsync(int userId)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT * FROM dbo.Pedido WHERE IdUsuario = @UserId";
        var dbModels = await connection.QueryAsync<OrderDbModel>(query, new { UserId = userId });
        return dbModels.Select(m => m.ToDomain());
    }
}
