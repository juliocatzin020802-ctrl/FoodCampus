namespace FoodCampus.Infrastructure.Persistence.Models;

public class OrderDetailDbModel
{
    public int IdDetalle { get; set; }
    public int IdPedido { get; set; }
    public int IdPlatillo { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}
