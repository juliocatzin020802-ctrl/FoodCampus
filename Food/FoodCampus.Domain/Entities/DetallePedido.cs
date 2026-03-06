namespace FoodCampus.Domain.Entities;

public class DetallePedido
{
    public int IdDetalle { get; set; }
    public int IdPedido { get; set; }
    public int IdPlatillo { get; set; }

    public int Cantidad
    {
        get;
        set => field = value <= 0 
            ? throw new ArgumentException("La cantidad debe ser mayor a 0") 
            : value;
    }

    public decimal Subtotal { get; set; }
}
