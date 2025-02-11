using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for Product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Productname: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateProductCommandValidator()
    {
        // RuleFor(Product => Product.Id);//.SetValidator(new EmailValidator());
        // RuleFor(Product => Product.Name).NotEmpty().Length(3, 50);
        // RuleFor(Product => Product.Description);//.SetValidator(new PasswordValidator());
        // RuleFor(Product => Product.UnitPrice);//.Matches(@"^\+?[1-9]\d{1,14}$");
        // RuleFor(Product => Product.IsAvailable);//.NotEqual(ProductStatus.Unknown);
    }
}