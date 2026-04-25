namespace InventorySystem.Client.Models;

public class StockMovementDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Type { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}