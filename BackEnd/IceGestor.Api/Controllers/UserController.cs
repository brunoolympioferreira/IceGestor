using IceGestor.Application.Models.InputModels.User;
using IceGestor.Application.Models.ViewModels.User;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Application.Services.User.Login;
using IceGestor.Application.Services.User.UpdateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IceGestor.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICreateUserService _createUserService;
    private readonly IUserLoginService _loginUserService;
    private readonly IUpdateUserService _updateUserService;
    public UserController(ICreateUserService createUserService, IUserLoginService loginUserService, IUpdateUserService updateUserService)
    {
        _createUserService = createUserService;
        _loginUserService = loginUserService;
        _updateUserService = updateUserService;
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

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInputModel request)
    {
        await _updateUserService.Execute(request);

        return NoContent();
    }
}
