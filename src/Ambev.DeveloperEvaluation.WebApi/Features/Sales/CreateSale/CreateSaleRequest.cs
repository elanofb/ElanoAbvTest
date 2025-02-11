using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{     
        public int Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new();
}