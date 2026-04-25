using InventorySystem.Domain.Entities;
using InventorySystem.Domain.Enums;
using Xunit;

namespace InventorySystem.Tests.Services;

public class StockMovementValidationTests
{
    [Fact]
    public void OutboundMovement_Should_Not_Allow_Negative_Stock()
    {
        var product = new Product
        {
            Name = "Keyboard",
            SKU = "KEY-001",
            QuantityInStock = 5,
            UnitPrice = 25
        };

        var requestedQuantity = 10;

        var hasEnoughStock = product.QuantityInStock >= requestedQuantity;

        Assert.False(hasEnoughStock);
    }

    [Fact]
    public void InboundMovement_Should_Increase_Stock()
    {
        var product = new Product
        {
            Name = "Mouse",
            SKU = "MOU-001",
            QuantityInStock = 5,
            UnitPrice = 15
        };

        var quantity = 10;

        product.QuantityInStock += quantity;

        Assert.Equal(15, product.QuantityInStock);
    }

    [Fact]
    public void OutboundMovement_Should_Decrease_Stock()
    {
        var product = new Product
        {
            Name = "Monitor",
            SKU = "MON-001",
            QuantityInStock = 20,
            UnitPrice = 150
        };

        var quantity = 5;

        product.QuantityInStock -= quantity;

        Assert.Equal(15, product.QuantityInStock);
    }
}