using IceGestor.Application.Models.InputModels.Product;
using IceGestor.Application.Models.ViewModels;
using IceGestor.Application.Services.Product;
using IceGestor.Application.Services.Product.Category;
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
    public async Task<IActionResult> GetAllFlavors()
    {
        var result = await _getFlavorsService.GetAll();

        return Ok(result);
    }

    [HttpGet("flavor/{id}")]
    public async Task<IActionResult> GetFlavorById(int id)
    {
        var result = await _getFlavorsService.GetById(id);

        return Ok(result);
    }

    [HttpPut("flavor/{id}")]
    public async Task<IActionResult> UpdateFlavor(
        [FromServices] IUpdateFlavorService updateFlavorService,
        int id, [FromBody] FlavorInputModel model)
    {
        await updateFlavorService.Update(id, model);

        return NoContent();
    }

    [HttpDelete("flavor/{id}")]
    public async Task<IActionResult> DeleteFlavor([FromServices] IDeleteFlavorService deleteFlavorService,int id)
    {
        var result = await deleteFlavorService.Delete(id);

        return Ok(result);
    }

    [HttpPost("category")]
    public async Task<IActionResult> CreateCategory([FromServices] ICategoryService categoryService, [FromBody] CategoryInputModel inputModel)
    {
        BaseResult result = await categoryService.Create(inputModel);

        return Ok(result);
    }

    [HttpPut("category/{id}")]
    public async Task<IActionResult> UpdateCategory(
    [FromServices] ICategoryService categoryService,
    int id, [FromBody] CategoryInputModel model)
    {
        await categoryService.Update(id, model);

        return NoContent();
    }

    [HttpGet("category")]
    public async Task<IActionResult> GetAllCategories([FromServices] ICategoryService categoryService)
    {
        var result = await categoryService.GetAll();

        return Ok(result);
    }

    [HttpGet("category/{id}")]
    public async Task<IActionResult> GetCategoryById([FromServices] ICategoryService categoryService, int id)
    {
        var result = await categoryService.GetById(id);

        return Ok(result);
    }

    [HttpDelete("category/{id}")]
    public async Task<IActionResult> DeleteCategory([FromServices] ICategoryService categoryService, int id)
    {
        var result = await categoryService.Delete(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromServices] IProductService service, [FromBody] ProductInputModel inputModel)
    {
        BaseResult result = await service.Create(inputModel);

        return Ok(result);
    }
}
