namespace FoodCampus.Domain.Entities;

public class Restaurante
{
    public int Id { get; set; }

    public string Nombre
    {
        get;
        set => field = string.IsNullOrWhiteSpace(value) 
            ? throw new ArgumentException("El nombre es obligatorio") 
            : value;
    }

    public string Especialidad { get; set; }
    public TimeSpan HorarioApertura { get; set; }
    public TimeSpan HorarioCierre { get; set; }

    public bool EstaAbierto(TimeSpan hora) => hora >= HorarioApertura && hora <= HorarioCierre;
}
