using FoodCampus.Domain.Entities;

namespace FoodCampus.Domain.Interfaces;

public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurante>> GetAllAsync();
    Task<Restaurante?> GetByIdAsync(int id);
    Task<int> CreateAsync(Restaurante restaurante);
}
