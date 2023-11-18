using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Application.Services.User.Login;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICreateUserService _createUserService;
    private readonly IUserLoginService _loginUserService;
    public UserController(ICreateUserService createUserService, IUserLoginService loginUserService)
    {
        _createUserService = createUserService;
        _loginUserService = loginUserService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserInputModel inputModel)
    {
        UserCreatedViewModel result = await _createUserService.Execute(inputModel);

        return Ok(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserInputModel request)
    {
        var loginUserViewModel = await _loginUserService.Login(request);

        if (loginUserViewModel == null) return BadRequest();

        return Ok(loginUserViewModel);
    }
}
