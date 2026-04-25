namespace InventorySystem.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string SKU { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public int QuantityInStock { get; set; }

    public decimal UnitPrice { get; set; }

    public DateTime CreatedAt { get; set; }
}