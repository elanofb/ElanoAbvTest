using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;

public class CreateSaleHandlerTests
{   /*
    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly SaleDiscountService _discountService;
    private readonly CreateSaleHandler _handler;
    private readonly Mock<ISaleItemRepository> _saleItemRepositoryMock;
    private readonly Mock<IMessageBusService> _messageBusServiceMock;

    public SaleTests()
    {
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _mapperMock = new Mock<IMapper>();
        _saleItemRepositoryMock = new Mock<ISaleItemRepository>();
        _messageBusServiceMock = new Mock<IMessageBusService>();
        _discountService = new SaleDiscountService();

        _handler = new CreateSaleHandler(
            _saleRepositoryMock.Object,
            _mapperMock.Object,
            _saleItemRepositoryMock.Object,
            _messageBusServiceMock.Object,
            _discountService
        );
    }
    */

    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly SaleDiscountService _discountService;
    private readonly CreateSaleHandler _handler;
    private readonly Mock<ISaleItemRepository> _saleItemRepositoryMock;
    private readonly Mock<IMessageBusService> _messageBusServiceMock;

    public CreateSaleHandlerTests()
    {
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _mapperMock = new Mock<IMapper>();
        _discountService = new SaleDiscountService();

        //_handler = new CreateSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object, _discountService);
         _handler = new CreateSaleHandler(
            _saleRepositoryMock.Object,
            _mapperMock.Object,
            _saleItemRepositoryMock.Object,
            _messageBusServiceMock.Object,
            _discountService
        );
    }

    [Fact]
    public async Task CreateSaleHandler_Should_Call_Repository()
    {
        var command = new CreateSaleCommand
        {
            Items = new List<SaleItem> { new SaleItem { ProductId = 1, Quantity = 5, UnitPrice = 10m } }
        };

        var sale = new Sale { Items = command.Items };
        _mapperMock.Setup(m => m.Map<Sale>(command)).Returns(sale);
        _saleRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(sale);

        var result = await _handler.Handle(command, CancellationToken.None);

        _saleRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
