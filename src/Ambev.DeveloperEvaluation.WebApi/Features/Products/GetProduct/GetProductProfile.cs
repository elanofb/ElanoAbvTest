using AutoMapper;

using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Profile for mapping GetProduct feature requests to commands
/// </summary>
public class GetProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProduct feature
    /// </summary>
    public GetProductProfile()
    {
        CreateMap<int, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));
        //CreateMap<int, Application.Products.GetProduct.GetProductCommand>()
        //    .ConstructUsing(id => new Application.Products.GetProduct.GetProductCommand(id));

        CreateMap<GetProductResult, GetProductResponse>();
    }
}
