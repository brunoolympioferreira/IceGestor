using IceGestor.Application.Services.User.CreateUser;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICreateUserService _createUserService;
    public UserController(ICreateUserService createUserService)
    {
        _createUserService = createUserService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserInputModel inputModel)
    {
        UserCreatedViewModel result = await _createUserService.Execute(inputModel);

        return Ok(result);
    }
}
