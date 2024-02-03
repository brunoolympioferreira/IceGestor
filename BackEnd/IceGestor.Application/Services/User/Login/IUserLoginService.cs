using IceGestor.Application.Models.InputModels.User;
using IceGestor.Application.Models.ViewModels.User;

namespace IceGestor.Application.Services.User.Login;
public interface IUserLoginService
{
    Task<LoginUserViewModel> Login(LoginUserInputModel request);
}
