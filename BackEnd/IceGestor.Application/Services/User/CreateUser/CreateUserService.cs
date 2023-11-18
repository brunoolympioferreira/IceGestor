﻿using IceGestor.Application.Authentication;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.Nlog;
using IceGestor.CrossCutting.ViewModels.User;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.User.CreateUser;
public class CreateUserService : ICreateUserService
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IAuthService _authService;
    private readonly IloggerManager _logger;
    public CreateUserService(IUnityOfWork unityOfWork, IAuthService authService, IloggerManager logger)
    {
        _unityOfWork = unityOfWork;
        _authService = authService;
        _logger = logger;
    }
    public async Task<UserCreatedViewModel> Execute(CreateUserInputModel request)
    {
        try
        {
            _logger.LogInfo("Teste Log Info");
            await Validate(request);

            string passwordHash = _authService.ComputeSha256Hash(request.Password);

            Core.Entities.User user = new(request.Username, passwordHash, request.Email);

            await _unityOfWork.BeginTransactionAsync();

            await _unityOfWork.Users.AddAsync(user);

            await _unityOfWork.CompleteAsync();

            await _unityOfWork.CommitAsync();

            string token = _authService.GenerateJwtToken(user.Email, user.Username);

            return new UserCreatedViewModel
            {
                Username = user.Username,
                Email = user.Email,
                Token = token
            };
        }
        catch (IceGestorException ex)
        {
            _logger.LogError(ex.Message, new IceGestorException(ex.Message));
            throw;
        }

    }

    private async Task Validate(CreateUserInputModel request)
    {
        var validator = new CreateUserValidator();
        var result = validator.Validate(request);

        var existsUserWithEmail = await _unityOfWork.Users.ExistsUserWithEmail(request.Email);
        var existsUserWithUsername = await _unityOfWork.Users.ExistsUserWithUsername(request.Username);
        if (existsUserWithEmail)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", "E-mail já cadastrado"));
        else if (existsUserWithUsername)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("username", "Username já cadastrado"));

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrorsException(errorMessages);
        }
    }
}