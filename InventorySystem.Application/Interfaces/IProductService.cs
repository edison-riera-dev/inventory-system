using InventorySystem.Application.DTOs;

namespace InventorySystem.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync(string? category);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(ProductDto productDto);
    Task<bool> UpdateAsync(int id, ProductDto productDto);
    Task<bool> DeleteAsync(int id);
}