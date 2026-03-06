using FoodCampus.Domain.Entities;

namespace FoodCampus.Domain.Interfaces;

public interface IOrderRepository
{
    Task<int> CreateAsync(Pedido pedido);
    Task<IEnumerable<Pedido>> GetByUserIdAsync(int userId);
}
