using FluentValidation;
using IceGestor.CrossCutting.InputModels.User;
using System.Text.RegularExpressions;

namespace IceGestor.Application.Services.User.CreateUser;
public partial class CreateUserValidator : AbstractValidator<CreateUserInputModel>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull()
            .WithMessage("Username é obrigatório!");

        RuleFor(u => u.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("E-mail não válido!");
    }

    private bool ValidPassword(string password)
    {
        Regex regex = PasswordRegex();

        return regex.IsMatch(password);
    }

    [GeneratedRegex("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$")]
    private static partial Regex PasswordRegex();
}