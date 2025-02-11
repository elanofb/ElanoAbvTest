using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

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