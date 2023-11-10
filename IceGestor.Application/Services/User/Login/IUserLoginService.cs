using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;

namespace IceGestor.Application.Services.User.Login;
public interface IUserLoginService
{
    Task<LoginUserViewModel> Login(LoginUserInputModel request);
}
