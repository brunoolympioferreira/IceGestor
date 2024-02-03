using IceGestor.Application.Models.InputModels.User;

namespace IceGestor.Application.Services.User.UpdateUser;
public interface IUpdateUserService
{
    Task Execute(UpdateUserInputModel request);
}
