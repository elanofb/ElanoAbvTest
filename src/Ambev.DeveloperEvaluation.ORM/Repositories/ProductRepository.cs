using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
    
    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    //public async Task<Product?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    // public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)    
    // {
    //     await _context.Products.Update(product);
    //     //await _context.Products.AddAsync(product, cancellationToken);
    //     await _context.SaveChangesAsync(cancellationToken);
    //     return product;
    // }

}
