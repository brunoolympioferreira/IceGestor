using IceGestor.Application.Authentication;
using IceGestor.Core.Entities;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.Infra.Persistence;
using Microsoft.AspNetCore.Builder;

namespace IceGestor.Application.Services.User.UpdateUser;
public class UpdateUserService : IUpdateUserService
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IAuthService _authService;
    public UpdateUserService(IUnityOfWork unityOfWork, IAuthService authService)
    {
        _unityOfWork = unityOfWork;
        _authService = authService;
    }
    public async Task Execute(UpdateUserInputModel request)
    {
        Validate(request);

        Core.Entities.User user = await _unityOfWork.Users.GetUserById(request.Id);

        string passwordHash = _authService.ComputeSha256Hash(request.Password);

        user.UpdateUser(passwordHash, request.Email);

        await _unityOfWork.BeginTransactionAsync();

        _unityOfWork.Users.Update(user);

        await _unityOfWork.CompleteAsync();

        await _unityOfWork.CommitAsync();
    }

    private async void Validate(UpdateUserInputModel request)
    {
        var validator = new UpdateUserValidator();
        var result = validator.Validate(request);

        var existsUserWithEmail = await _unityOfWork.Users.ExistsUserWithEmail(request.Email);
        if (existsUserWithEmail)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", "E-mail já cadastrado"));

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}
