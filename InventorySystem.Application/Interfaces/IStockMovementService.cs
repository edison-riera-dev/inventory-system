using InventorySystem.Application.DTOs;

namespace InventorySystem.Application.Interfaces;

public interface IStockMovementService
{
    Task<List<StockMovementDto>> GetByProductIdAsync(int productId);

    Task<StockMovementDto> CreateAsync(int productId, StockMovementDto dto);
}