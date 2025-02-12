//using AutoMapper;
//using MediatR;
//using FluentValidation;
//using Ambev.DeveloperEvaluation.Domain.Repositories;

//namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

///// <summary>
///// Handler for processing GetSaleCommand requests
///// </summary>
//public class GetSaleListHandler : IRequestHandler<GetSaleListCommand, GetSaleListResult>
//{
//    private readonly ISaleRepository _saleRepository;
//    private readonly IMapper _mapper;

//    public GetSaleListHandler(
//        ISaleRepository saleRepository,
//        IMapper mapper)
//    {
//        _saleRepository = saleRepository;
//        _mapper = mapper;
//    }

//    public async Task<GetSaleListResult> Handle(CancellationToken cancellationToken)
//    {
//        var sales = await _saleRepository.GetAllAsync(cancellationToken);
//        if (sales == null)
//            throw new KeyNotFoundException($"No Sales!");

//        return _mapper.Map<GetSaleListResult>(sales);
//    }
//}
