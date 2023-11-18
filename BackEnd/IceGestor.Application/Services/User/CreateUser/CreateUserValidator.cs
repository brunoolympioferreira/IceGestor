using FluentValidation;
using IceGestor.CrossCutting.InputModels.User;
using System.Text.RegularExpressions;

namespace IceGestor.Application.Services.User.CreateUser;
public class CreateUserValidator : AbstractValidator<CreateUserInputModel>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull()
            .WithMessage("Username não pode estar vazio");

        RuleFor(u => u.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("E-mail não válido!");
    }

    private static bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}