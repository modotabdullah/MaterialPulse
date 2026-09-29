using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Domain.Entities;

public class StockTransaction
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public decimal Quantity { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
    public string? PerformedByUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;
}