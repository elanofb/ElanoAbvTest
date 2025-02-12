using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<Sale?>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
