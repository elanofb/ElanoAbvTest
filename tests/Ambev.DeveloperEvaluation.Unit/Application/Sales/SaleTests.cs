using Xunit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleTests
{
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

    [Fact]
    public async Task CreateSale_Should_Apply_10_Percent_Discount_For_4_To_9_Items()
    {
        var command = new CreateSaleCommand
        {
            Items = new List<SaleItem>
            {
                new SaleItem { ProductId = 1, Quantity = 5, UnitPrice = 10m }
            }
        };

        var sale = new Sale { Items = command.Items };
        _mapperMock.Setup(m => m.Map<Sale>(command)).Returns(sale);
        _saleRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(sale);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.Equal(5, result.Items[0].Quantity);
        Assert.Equal(5m, result.Items[0].Discount);
    }

    [Fact]
    public async Task CreateSale_Should_Throw_Exception_When_Quantity_Exceeds_20()
    {
        var command = new CreateSaleCommand
        {
            Items = new List<SaleItem>
            {
                new SaleItem { ProductId = 1, Quantity = 25, UnitPrice = 10m }
            }
        };

        await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
    }
}