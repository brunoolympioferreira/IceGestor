using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Services.Product.Flavor.CreateFlavor;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICreateFlavorService _createFlavorService;

    public ProductController(ICreateFlavorService createFlavorService)
    {
        _createFlavorService = createFlavorService;
    }

    [HttpPost("Flavor")]
    public async Task<IActionResult> CreateFlavor([FromBody] FlavorInputModel inputModel)
    {
        BaseResult result = await _createFlavorService.Execute(inputModel);

        return Ok(result);
    }
}
