using Xunit;
using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;

public class SaleItemTests
{
    private readonly SaleDiscountService _discountService;

    public SaleItemTests()
    {
        _discountService = new SaleDiscountService();
    }

    [Fact]
    public void SaleItem_Should_Not_Apply_Discount_When_Less_Than_4()
    {
        var saleItems = new List<SaleItem>
        {
            new SaleItem { ProductId = 1, Quantity = 3, UnitPrice = 10m }
        };

        _discountService.ApplyDiscounts(saleItems);

        Assert.Equal(0, saleItems[0].Discount);
        Assert.Equal(30, saleItems[0].Total);
    }
}