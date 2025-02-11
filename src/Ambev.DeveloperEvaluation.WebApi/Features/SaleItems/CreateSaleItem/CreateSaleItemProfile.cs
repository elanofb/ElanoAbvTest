using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleItemResponse>();
    }
}
