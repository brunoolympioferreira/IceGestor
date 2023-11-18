using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;

namespace IceGestor.Application.Services.User.CreateUser;
public interface ICreateUserService
{
    Task<UserCreatedViewModel> Execute(CreateUserInputModel request);
}
