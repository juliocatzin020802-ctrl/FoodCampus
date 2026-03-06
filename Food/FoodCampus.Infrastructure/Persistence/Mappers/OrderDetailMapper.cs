using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Persistence.Models;

namespace FoodCampus.Infrastructure.Persistence.Mappers;

public static class OrderDetailMapper
{
    public static DetallePedido ToDomain(this OrderDetailDbModel dbModel)
    {
        return new DetallePedido
        {
            IdDetalle = dbModel.IdDetalle,
            IdPedido = dbModel.IdPedido,
            IdPlatillo = dbModel.IdPlatillo,
            Cantidad = dbModel.Cantidad,
            Subtotal = dbModel.Subtotal
        };
    }

    public static OrderDetailDbModel ToDbModel(this DetallePedido domain)
    {
        return new OrderDetailDbModel
        {
            IdDetalle = domain.IdDetalle,
            IdPedido = domain.IdPedido,
            IdPlatillo = domain.IdPlatillo,
            Cantidad = domain.Cantidad,
            Subtotal = domain.Subtotal
        };
    }
}
