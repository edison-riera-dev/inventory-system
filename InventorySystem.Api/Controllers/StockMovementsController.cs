using InventorySystem.Application.DTOs;
using InventorySystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Api.Controllers;

[ApiController]
[Route("api/products/{productId:int}/movements")]
[Authorize]
public class StockMovementsController : ControllerBase
{
    private readonly IStockMovementService stockMovementService;

    public StockMovementsController(IStockMovementService stockMovementService)
    {
        this.stockMovementService = stockMovementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByProductId(int productId)
    {
        var movements = await stockMovementService.GetByProductIdAsync(productId);
        return Ok(movements);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int productId, StockMovementDto dto)
    {
        try
        {
            var movement = await stockMovementService.CreateAsync(productId, dto);
            return Created(string.Empty, movement);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}