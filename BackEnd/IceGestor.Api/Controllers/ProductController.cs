using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Services.Product.Flavor.CreateFlavor;
using IceGestor.Application.Services.Product.Flavor.DeleteFlavor;
using IceGestor.Application.Services.Product.Flavor.GetFlavors;
using IceGestor.Application.Services.Product.Flavor.UpdateFlavor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
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

    [HttpGet("flavors")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getFlavorsService.GetAll();

        return Ok(result);
    }

    [HttpGet("flavor/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getFlavorsService.GetById(id);

        return Ok(result);
    }

    [HttpPut("flavor/{id}")]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateFlavorService updateFlavorService,
        int id, [FromBody] FlavorInputModel model)
    {
        await updateFlavorService.Update(id, model);

        return NoContent();
    }

    [HttpDelete("flavor/{id}")]
    public async Task<IActionResult> Delete([FromServices] IDeleteFlavorService deleteFlavorService,int id)
    {
        var result = await deleteFlavorService.Delete(id);

        return Ok(result);
    }
}
