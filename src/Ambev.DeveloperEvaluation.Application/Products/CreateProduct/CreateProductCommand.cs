// using MediatR;
// using Ambev.DeveloperEvaluation.Domain.Entities;
// using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
// using Ambev.DeveloperEvaluation.Application.Products.Commands;

// namespace Ambev.DeveloperEvaluation.Application.Products.Commands
// {
//     public record CreateProductCommand(string Name, string Description, decimal UnitPrice, bool IsAvailable) : IRequest<ProductResult>;
//     //public record CreateProductCommand(Product Product) : IRequest<CreateProductResult>;
// }
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductResult>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public bool IsAvailable { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}