using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;

namespace FoodCampus.Application.UseCases;

public class RegisterRestaurant
{
    private readonly IRestaurantRepository _repository;

    public RegisterRestaurant(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> ExecuteAsync(Restaurante restaurante)
    {
        return await _repository.CreateAsync(restaurante);
    }
}
