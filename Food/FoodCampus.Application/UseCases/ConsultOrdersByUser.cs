using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;

namespace FoodCampus.Application.UseCases;

public class ConsultOrdersByUser
{
    private readonly IOrderRepository _repository;

    public ConsultOrdersByUser(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Pedido>> ExecuteAsync(int userId)
    {
        return await _repository.GetByUserIdAsync(userId);
    }
}
