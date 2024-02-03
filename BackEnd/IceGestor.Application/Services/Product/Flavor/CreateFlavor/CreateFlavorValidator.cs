using FluentValidation;
using IceGestor.Application.Models.InputModels.Product;

namespace IceGestor.Application.Services.Product.Flavor.CreateFlavor;
public class CreateFlavorValidator : AbstractValidator<FlavorInputModel>
{
    public CreateFlavorValidator()
    {
        RuleFor(f => f.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Este campo não pode ser vazio ou nulo.");

        RuleFor(f => f.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Este campo não pode ser nulo ou vazio.");
            
    }
}
