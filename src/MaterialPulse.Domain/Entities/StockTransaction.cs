using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Domain.Entities;

public class StockTransaction
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public decimal Quantity { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string? SourceDestination { get; set; }
    public string? UserId { get; set; }

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;

    public int? ProductionRunId { get; set; }
    public ProductionRun? ProductionRun { get; set; }
}