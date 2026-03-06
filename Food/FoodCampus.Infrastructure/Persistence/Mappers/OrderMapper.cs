using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Persistence.Models;

namespace FoodCampus.Infrastructure.Persistence.Mappers;

public static class OrderMapper
{
    public static Pedido ToDomain(this OrderDbModel dbModel)
    {
        return new Pedido
        {
            IdPedido = dbModel.IdPedido,
            IdRestaurante = dbModel.IdRestaurante,
            IdUsuario = dbModel.IdUsuario,
            FechaHora = dbModel.FechaHora,
            CostoEnvio = dbModel.CostoEnvio
        };
    }

    public static OrderDbModel ToDbModel(this Pedido domain)
    {
        return new OrderDbModel
        {
            IdPedido = domain.IdPedido,
            IdRestaurante = domain.IdRestaurante,
            IdUsuario = domain.IdUsuario,
            FechaHora = domain.FechaHora,
            CostoEnvio = domain.CostoEnvio
        };
    }
}
