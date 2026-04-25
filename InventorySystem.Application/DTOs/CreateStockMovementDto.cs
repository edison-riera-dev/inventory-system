using InventorySystem.Domain.Enums;

namespace InventorySystem.Application.DTOs;

public class CreateStockMovementDto
{
    public MovementType Type { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;
}