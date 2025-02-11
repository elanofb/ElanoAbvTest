using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for SaleItem entity operations
/// </summary>
public interface ISaleItemRepository
{
    Task<SaleItem> CreateAsync(SaleItem saleitem, CancellationToken cancellationToken = default);
    Task<SaleItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    //Task<SaleItem?> GetBySaleIdAsync(int saleid, CancellationToken cancellationToken = default);
    Task<List<SaleItem?>> GetBySaleIdAsync(int saleid, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
