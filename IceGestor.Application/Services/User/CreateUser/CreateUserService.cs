using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;

namespace IceGestor.Application.Services.User.CreateUser;
public class CreateUserService : ICreateUserService
{
    public Task<UserCreatedViewModel> Execute(CreateUserInputModel request)
    {
        throw new NotImplementedException();
    }
}
