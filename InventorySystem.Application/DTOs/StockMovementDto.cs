using InventorySystem.Domain.Enums;

namespace InventorySystem.Application.DTOs;

public class StockMovementDto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public MovementType Type { get; set; }

    public int Quantity { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }
}