using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Interfaces;

namespace FoodCampus.Application.UseCases;

public class RegisterOrder
{
    private readonly IOrderRepository _orderRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public RegisterOrder(IOrderRepository orderRepository, IRestaurantRepository restaurantRepository)
    {
        _orderRepository = orderRepository;
        _restaurantRepository = restaurantRepository;
    }

    public async Task<int> ExecuteAsync(Pedido pedido)
    {
        var restaurante = await _restaurantRepository.GetByIdAsync(pedido.IdRestaurante);
        if (restaurante == null)
        {
            throw new Exception($"El restaurante con ID {pedido.IdRestaurante} no existe.");
        }

        return await _orderRepository.CreateAsync(pedido);
    }
}
