using FluentValidation;
using IceGestor.Core.Entities;

namespace IceGestor.Application.Models.InputModels.Stock;
public class ProductStockInputModel
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public ProductStock ToEntity() => new(ProductId, Quantity);
}
