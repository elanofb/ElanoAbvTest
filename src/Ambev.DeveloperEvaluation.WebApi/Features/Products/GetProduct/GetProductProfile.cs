using AutoMapper;

using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<int, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));

        CreateMap<GetProductResult, GetProductResponse>();
    }
}
