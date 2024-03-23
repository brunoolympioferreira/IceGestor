using FluentValidation;
using IceGestor.Application.Models.InputModels.Stock;

namespace IceGestor.Application.Services.Stock;
public class ProductStockValidator : AbstractValidator<ProductStockInputModel>
{
    public ProductStockValidator()
    {
        RuleFor(s => s.ProductId).NotNull().WithMessage("Id do Produto não pode ser nulo");
        RuleFor(s => s.Quantity).NotNull().WithMessage("Quantidade não pode ser nula");
    }
}
