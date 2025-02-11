using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Salename: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        // RuleFor(sale => sale.Email).SetValidator(new EmailValidator());
        // RuleFor(sale => sale.Salename).NotEmpty().Length(3, 50);
        // RuleFor(sale => sale.Password).SetValidator(new PasswordValidator());
        // RuleFor(sale => sale.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        // // RuleFor(sale => sale.Status).NotEqual(SaleStatus.Unknown);
        // // RuleFor(sale => sale.Role).NotEqual(SaleRole.None);
    }
}