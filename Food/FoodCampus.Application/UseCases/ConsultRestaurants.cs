using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;

namespace FoodCampus.Application.UseCases;

public class ConsultRestaurants
{
    private readonly IRestaurantRepository _repository;

    public ConsultRestaurants(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Restaurante>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
