using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemCommand that defines validation rules for saleitem creation command.
/// </summary>
public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - SaleItemname: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateSaleItemCommandValidator()
    {
        // RuleFor(saleitem => saleitem.Email).SetValidator(new EmailValidator());
        // RuleFor(saleitem => saleitem.SaleItemname).NotEmpty().Length(3, 50);
        // RuleFor(saleitem => saleitem.Password).SetValidator(new PasswordValidator());
        // RuleFor(saleitem => saleitem.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        // RuleFor(saleitem => saleitem.Status).NotEqual(SaleItemStatus.Unknown);
        // RuleFor(saleitem => saleitem.Role).NotEqual(SaleItemRole.None);
    }
}