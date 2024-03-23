using IceGestor.Application.Models.InputModels.Stock;
using IceGestor.Application.Services.Product;
using IceGestor.Application.Services.Stock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductStocksController : ControllerBase
{
    private readonly IProductStockService _productStockService;
    public ProductStocksController(IProductStockService productStockService)
    {
        _productStockService = productStockService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductStockInputModel model)
    {
        var result = await _productStockService.Create(model);

        return Ok(result);
    }
}
