using FluentValidation;
using IceGestor.Application.Models.InputModels.Product;

namespace IceGestor.Application.Services.Product.Category;
public class CategoryValidator : AbstractValidator<CategoryInputModel>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Este campo não pode ser nulo ou vazio");
    }
}
