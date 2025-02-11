using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including salename, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public int Id { get; set; }
    public string SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public string Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new();


    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}