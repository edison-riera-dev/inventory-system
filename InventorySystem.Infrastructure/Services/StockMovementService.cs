using InventorySystem.Application.DTOs;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
using InventorySystem.Domain.Enums;
using InventorySystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Services;

public class StockMovementService : IStockMovementService
{
    private readonly AppDbContext db;

    public StockMovementService(AppDbContext db)
    {
        this.db = db;
    }

    public async Task<List<StockMovementDto>> GetByProductIdAsync(int productId)
    {
        return await db.StockMovements
            .Where(s => s.ProductId == productId)
            .OrderByDescending(s => s.Timestamp)
            .Select(s => new StockMovementDto
            {
                Id = s.Id,
                ProductId = s.ProductId,
                Type = s.Type,
                Quantity = s.Quantity,
                Reason = s.Reason,
                Timestamp = s.Timestamp
            })
            .ToListAsync();
    }

    public async Task<StockMovementDto> CreateAsync(int productId, StockMovementDto dto)
    {
        var product = await db.Products.FindAsync(productId);

        if (product is null)
            throw new Exception("Producto no encontrado.");

        if (dto.Quantity <= 0)
            throw new Exception("La cantidad debe ser mayor a cero.");

        if (dto.Type == MovementType.Outbound)
        {
            if (product.QuantityInStock < dto.Quantity)
                throw new Exception("Stock insuficiente.");

            product.QuantityInStock -= dto.Quantity;
        }
        else if (dto.Type == MovementType.Inbound)
        {
            product.QuantityInStock += dto.Quantity;
        }
        else
        {
            throw new Exception("Tipo de movimiento inválido.");
        }

        var movement = new StockMovement
        {
            ProductId = productId,
            Type = dto.Type,
            Quantity = dto.Quantity,
            Reason = dto.Reason,
            Timestamp = DateTime.UtcNow
        };

        db.StockMovements.Add(movement);
        await db.SaveChangesAsync();

        return new StockMovementDto
        {
            Id = movement.Id,
            ProductId = movement.ProductId,
            Type = movement.Type,
            Quantity = movement.Quantity,
            Reason = movement.Reason,
            Timestamp = movement.Timestamp
        };
    }
}