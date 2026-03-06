namespace FoodCampus.Infrastructure.Persistence.Models;

public class RestaurantDbModel
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public TimeSpan HorarioApertura { get; set; }
    public TimeSpan HorarioCierre { get; set; }
}
