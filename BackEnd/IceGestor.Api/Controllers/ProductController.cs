using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Services.Product.Flavor.CreateFlavor;
using IceGestor.Application.Services.Product.Flavor.GetFlavors;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICreateFlavorService _createFlavorService;
    private readonly IGetFlavorsService _getFlavorsService;

    public ProductController(ICreateFlavorService createFlavorService, IGetFlavorsService getFlavorsService)
    {
        _createFlavorService = createFlavorService;
        _getFlavorsService = getFlavorsService;
    }

    [HttpPost("Flavor")]
    public async Task<IActionResult> CreateFlavor([FromBody] FlavorInputModel inputModel)
    {
        BaseResult result = await _createFlavorService.Execute(inputModel);

        return Ok(result);
    }

    [HttpGet("flavor")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getFlavorsService.GetAll();

        return Ok(result);
    }
}
