using MaterialPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaterialPulse.Application.Common;

public interface IApplicationDbContext
{
    DbSet<Material> Materials { get; }
    DbSet<StockTransaction> StockTransactions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}