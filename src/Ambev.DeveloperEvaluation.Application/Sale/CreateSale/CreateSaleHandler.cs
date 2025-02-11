using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.ORM.Repositories;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ISaleItemRepository _saleItemRepository;
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ISaleItemRepository saleItemRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _saleItemRepository = saleItemRepository;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingSale != null)
            throw new InvalidOperationException($"Sale with ID {command.Id} already exists");

        var sale = _mapper.Map<Sale>(command);
        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);        

        //#region Sales Item

        //foreach(var saleitem in command.Items){
        //    saleitem.SaleId = createdSale.Id; // Garantir que SaleId foi preenchido
        //    var createdSaleItem = await _saleItemRepository.CreateAsync(saleitem, cancellationToken);            
        //    //var saleitemMap = _mapper.Map<SaleItem>(createdSaleItem);
        //}

        //#endregion

        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
