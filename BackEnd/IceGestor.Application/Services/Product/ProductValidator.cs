using FluentValidation;
using IceGestor.Application.Models.InputModels.Product;

namespace IceGestor.Application.Services.Product;
public class ProductValidator : AbstractValidator<ProductInputModel>
{
    public ProductValidator()
    {
        RuleFor(p => p.Amount)
            .NotNull()
            .WithMessage("Preço não pode ser nulo");

        RuleFor(p => p.FlavorId)
            .NotNull()
            .WithMessage("Id Sabor não pode ser nulo");

        RuleFor(p => p.CategoryId)
            .NotNull()
            .WithMessage("Id Categoria não pode ser nulo");
    }
}
