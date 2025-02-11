using Xunit;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using System;
using AutoFixture;

public class SaleDiscountServiceTests
{
    private readonly SaleDiscountService _discountService;

    public SaleDiscountServiceTests()
    {
        _discountService = new SaleDiscountService();
    }

    [Fact]
    public void Should_Not_Apply_Discount_For_Less_Than_4_Items()
    {
        // Gera um número aleatório automaticamente
        // var rand = new Random();
        // int prodid = rand.Next(1,10000);
        var fixture = new Fixture();
        int productId = fixture.Create<int>();

        var saleItems = new List<SaleItem>
        {
            new SaleItem { ProductId = productId, Quantity = 3, UnitPrice = 10m }
        };

        _discountService.ApplyDiscounts(saleItems);

        Assert.Equal(0, saleItems[0].Discount);
        Assert.Equal(30, saleItems[0].Total);
    }

    [Fact]
    public void Should_Apply_10_Percent_Discount_For_4_To_9_Items()
    {
        var saleItems = new List<SaleItem>
        {
            new SaleItem { ProductId = new Fixture().Create<int>(), Quantity = 5, UnitPrice = 10m }
        };

        _discountService.ApplyDiscounts(saleItems);

        Assert.Equal(5, saleItems[0].Discount);
        Assert.Equal(45, saleItems[0].Total);
    }

    [Fact]
    public void Should_Apply_20_Percent_Discount_For_10_To_20_Items()
    {
        var saleItems = new List<SaleItem>
        {
            new SaleItem { ProductId = new Fixture().Create<int>(), Quantity = 15, UnitPrice = 10m }
        };

        _discountService.ApplyDiscounts(saleItems);

        Assert.Equal(30, saleItems[0].Discount);
        Assert.Equal(120, saleItems[0].Total);
    }

    [Fact]
    public void Should_Throw_Exception_When_Items_Exceed_20()
    {
        var saleItems = new List<SaleItem>
        {
            new SaleItem { ProductId = new Fixture().Create<int>(), Quantity = 25, UnitPrice = 10m }
        };

        Assert.Throws<InvalidOperationException>(() => _discountService.ApplyDiscounts(saleItems));
    }
}
