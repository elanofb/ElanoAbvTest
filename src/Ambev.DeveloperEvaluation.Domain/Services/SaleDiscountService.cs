using System;
using System.Collections.Generic;
using System.Linq;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleDiscountService
    {
        public void ApplyDiscounts(List<SaleItem> saleItems)
        {
            foreach (var item in saleItems)
            {
                if (item.Quantity < 4)
                {
                    // Nenhum desconto aplicado
                    item.Discount = 0;
                }
                else if (item.Quantity >= 4 && item.Quantity < 10)
                {
                    // Aplicar 10% de desconto
                    item.Discount = 0.10m * item.UnitPrice * item.Quantity;
                }
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    // Aplicar 20% de desconto
                    item.Discount = 0.20m * item.UnitPrice * item.Quantity;
                }
                else
                {
                    // Lançar exceção caso a quantidade seja maior que 20
                    throw new InvalidOperationException($"Cannot sell more than 20 units of product {item.ProductId}.");
                }

                // Recalcula o preço total do item
                item.Total = (item.UnitPrice * item.Quantity) - item.Discount;
            }
        }
    }
}
