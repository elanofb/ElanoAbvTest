using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        // RuleFor(Product => Product.Id);//.SetValidator(new EmailValidator());
        // RuleFor(Product => Product.Name).NotEmpty().Length(3, 50);
        // RuleFor(Product => Product.Description);//.SetValidator(new PasswordValidator());
        // RuleFor(Product => Product.UnitPrice);//.Matches(@"^\+?[1-9]\d{1,14}$");
        // RuleFor(Product => Product.IsAvailable);//.NotEqual(ProductStatus.Unknown);
    }
}