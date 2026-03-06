namespace FoodCampus.Infrastructure.Persistence.Models;

public class OrderDbModel
{
    public int IdPedido { get; set; }
    public int IdRestaurante { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaHora { get; set; }
    public decimal CostoEnvio { get; set; }
}
