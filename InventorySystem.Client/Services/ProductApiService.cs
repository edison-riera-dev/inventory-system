using System.Net.Http.Json;
using InventorySystem.Client.Models;

namespace InventorySystem.Client.Services;

public class ProductApiService
{
    private readonly HttpClient http;

    public ProductApiService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<List<ProductDto>> GetProducts(string? category = null, int? lowStockThreshold = null)
    {
        var query = new List<string>();

        if (!string.IsNullOrWhiteSpace(category))
            query.Add($"category={Uri.EscapeDataString(category)}");

        if (lowStockThreshold.HasValue)
            query.Add($"lowStockThreshold={lowStockThreshold.Value}");

        var url = "api/products";

        if (query.Any())
            url += "?" + string.Join("&", query);

        return await http.GetFromJsonAsync<List<ProductDto>>(url) ?? new();
    }

    public async Task<ProductDto?> GetProductById(int id)
    {
        return await http.GetFromJsonAsync<ProductDto>($"api/products/{id}");
    }

    public async Task CreateProduct(CreateProductDto dto)
    {
        var response = await http.PostAsJsonAsync("api/products", dto);

        if (!response.IsSuccessStatusCode)
            throw new Exception(await response.Content.ReadAsStringAsync());
    }

    public async Task UpdateProduct(int id, UpdateProductDto dto)
    {
        var response = await http.PutAsJsonAsync($"api/products/{id}", dto);

        if (!response.IsSuccessStatusCode)
            throw new Exception(await response.Content.ReadAsStringAsync());
    }

    public async Task DeleteProduct(int id)
    {
        var response = await http.DeleteAsync($"api/products/{id}");

        if (!response.IsSuccessStatusCode)
            throw new Exception(await response.Content.ReadAsStringAsync());
    }

    public async Task<List<StockMovementDto>> GetMovements(int productId)
    {
        return await http.GetFromJsonAsync<List<StockMovementDto>>(
            $"api/products/{productId}/movements") ?? new();
    }

    public async Task CreateMovement(int productId, CreateStockMovementDto dto)
    {
        var response = await http.PostAsJsonAsync(
            $"api/products/{productId}/movements", dto);

        if (!response.IsSuccessStatusCode)
            throw new Exception(await response.Content.ReadAsStringAsync());
    }
}