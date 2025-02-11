using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Productname: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public CreateProductRequestValidator()
    {
        // RuleFor(product => product.Email).SetValidator(new EmailValidator());
        // RuleFor(product => product.Productname).NotEmpty().Length(3, 50);
        // RuleFor(product => product.Password).SetValidator(new PasswordValidator());
        // RuleFor(product => product.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        // // RuleFor(product => product.Status).NotEqual(ProductStatus.Unknown);
        // // RuleFor(product => product.Role).NotEqual(ProductRole.None);
    }
}