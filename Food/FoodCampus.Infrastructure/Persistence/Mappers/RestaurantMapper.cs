using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Persistence.Models;

namespace FoodCampus.Infrastructure.Persistence.Mappers;

public static class RestaurantMapper
{
    public static Restaurante ToDomain(this RestaurantDbModel dbModel)
    {
        return new Restaurante
        {
            Id = dbModel.Id,
            Nombre = dbModel.Nombre,
            Especialidad = dbModel.Especialidad,
            HorarioApertura = dbModel.HorarioApertura,
            HorarioCierre = dbModel.HorarioCierre
        };
    }

    public static RestaurantDbModel ToDbModel(this Restaurante domain)
    {
        return new RestaurantDbModel
        {
            Id = domain.Id,
            Nombre = domain.Nombre,
            Especialidad = domain.Especialidad,
            HorarioApertura = domain.HorarioApertura,
            HorarioCierre = domain.HorarioCierre
        };
    }
}
