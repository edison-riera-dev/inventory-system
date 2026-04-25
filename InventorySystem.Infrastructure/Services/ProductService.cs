using InventorySystem.Application.DTOs;
using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
using InventorySystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext db;

    public ProductService(AppDbContext db)
    {
        this.db = db;
    }

    public async Task<List<ProductDto>> GetAllAsync(string? category)
    {
        var query = db.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(p => p.Category == category);
        }

        return await query
            .OrderBy(p => p.Name)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Category = p.Category,
                QuantityInStock = p.QuantityInStock,
                UnitPrice = p.UnitPrice,
                CreatedAt = p.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        return await db.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Category = p.Category,
                QuantityInStock = p.QuantityInStock,
                UnitPrice = p.UnitPrice,
                CreatedAt = p.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ProductDto> CreateAsync(ProductDto productDto)
    {
        var skuExists = await db.Products.AnyAsync(p => p.SKU == productDto.SKU);

        if (skuExists)
            throw new Exception("El SKU ya existe.");

        if (productDto.QuantityInStock < 0)
            throw new Exception("El stock inicial no puede ser negativo.");

        if (productDto.UnitPrice <= 0)
            throw new Exception("El precio debe ser mayor a cero.");

        var product = new Product
        {
            Name = productDto.Name,
            SKU = productDto.SKU,
            Category = productDto.Category,
            QuantityInStock = productDto.QuantityInStock,
            UnitPrice = productDto.UnitPrice,
            CreatedAt = DateTime.UtcNow
        };

        db.Products.Add(product);
        await db.SaveChangesAsync();

        productDto.Id = product.Id;
        productDto.CreatedAt = product.CreatedAt;

        return productDto;
    }

    public async Task<bool> UpdateAsync(int id, ProductDto productDto)
    {
        var product = await db.Products.FindAsync(id);

        if (product is null)
            return false;

        var skuExists = await db.Products
            .AnyAsync(p => p.SKU == productDto.SKU && p.Id != id);

        if (skuExists)
            throw new Exception("El SKU ya existe.");

        if (productDto.UnitPrice <= 0)
            throw new Exception("El precio debe ser mayor a cero.");

        product.Name = productDto.Name;
        product.SKU = productDto.SKU;
        product.Category = productDto.Category;
        product.UnitPrice = productDto.UnitPrice;

        await db.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await db.Products.FindAsync(id);

        if (product is null)
            return false;

        db.Products.Remove(product);
        await db.SaveChangesAsync();

        return true;
    }
}