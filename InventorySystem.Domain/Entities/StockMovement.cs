using InventorySystem.Domain.Enums;

namespace InventorySystem.Domain.Entities;

public class StockMovement
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public MovementType Type { get; set; }

    public int Quantity { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Product? Product { get; set; }
}