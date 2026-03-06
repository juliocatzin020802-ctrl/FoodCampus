namespace FoodCampus.Domain.Entities;

public class Pedido
{
    public int IdPedido { get; set; }
    public int IdRestaurante { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;

    public decimal CostoEnvio
    {
        get;
        set => field = value < 0 
            ? throw new ArgumentException("El costo de envío no puede ser negativo") 
            : value;
    }

    public List<DetallePedido> Detalles { get; set; } = new();
}
