using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }
    
    public async Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<List<Sale?>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Sales.Include(s => s.Items).ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    //public async Task<Sale?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    // public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)    
    // {
    //     await _context.Sales.Update(sale);
    //     //await _context.Sales.AddAsync(sale, cancellationToken);
    //     await _context.SaveChangesAsync(cancellationToken);
    //     return sale;
    // }

}
