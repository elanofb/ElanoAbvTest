using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Domain.Events;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMessageBusService _messageBusService;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ISaleItemRepository saleItemRepository, IMessageBusService messageBusService)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _saleItemRepository = saleItemRepository;
        _messageBusService = messageBusService; 
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

        // Publicando evento no Rebus após salvar a venda.
        await _messageBusService.PublishEvent(new OrderCreatedEvent(createdSale.SaleNumber, createdSale.Customer, createdSale.TotalAmount));

        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
