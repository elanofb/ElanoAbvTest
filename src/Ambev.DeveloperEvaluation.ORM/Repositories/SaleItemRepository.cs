using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleItemRepository using Entity Framework Core
/// </summary>
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<SaleItem> CreateAsync(SaleItem saleitem, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddAsync(saleitem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return saleitem;
    }
    
    public async Task<SaleItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    //Task<SaleItem?> GetBySaleIdAsync(int saleid, CancellationToken cancellationToken = default);
    public async Task<List<SaleItem?>> GetBySaleIdAsync(int saleid, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.Where(o => o.SaleId == saleid).ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var saleitem = await GetByIdAsync(id, cancellationToken);
        if (saleitem == null)
            return false;

        _context.SaleItems.Remove(saleitem);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    //public async Task<SaleItem?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    // public async Task<SaleItem> UpdateAsync(SaleItem saleitem, CancellationToken cancellationToken = default)    
    // {
    //     await _context.SaleItems.Update(saleitem);
    //     //await _context.SaleItems.AddAsync(saleitem, cancellationToken);
    //     await _context.SaveChangesAsync(cancellationToken);
    //     return saleitem;
    // }

}
