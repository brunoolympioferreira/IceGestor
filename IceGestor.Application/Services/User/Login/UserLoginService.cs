using IceGestor.Application.Authentication;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.User.Login;
public class UserLoginService : IUserLoginService
{
    private readonly IAuthService _authService;
    private readonly IUnityOfWork _unityOfWork;

    public UserLoginService(IAuthService authService, IUnityOfWork unityOfWork)
    {
        _authService = authService;
        _unityOfWork = unityOfWork;
    }
    public async Task<LoginUserViewModel> Login(LoginUserInputModel request)
    {
        string passwordHash = _authService.ComputeSha256Hash(request.Password);

        Core.Entities.User user = await _unityOfWork.Users.GetUserByEmailAndPasswordAsync(request.Email, passwordHash)
            ?? throw new IceGestorException("Nome de usuário e/ou inválido");

        string token = _authService.GenerateJwtToken(user.Email, user.Username);

        return new LoginUserViewModel(user.Email, token);
    }
}
