using IceGestor.Application.Models.InputModels.User;
using IceGestor.Application.Models.ViewModels.User;

namespace IceGestor.Application.Services.User.CreateUser;
public interface ICreateUserService
{
    Task<UserCreatedViewModel> Execute(CreateUserInputModel request);
}
