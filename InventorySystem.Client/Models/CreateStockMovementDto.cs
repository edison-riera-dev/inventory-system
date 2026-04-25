namespace InventorySystem.Client.Models;

public class CreateStockMovementDto
{
    public int Type { get; set; } = 1;
    public int Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;
}