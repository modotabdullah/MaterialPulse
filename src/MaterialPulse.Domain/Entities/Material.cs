using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Domain.Entities;

public class Material
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
    public UnitOfMeasure Unit { get; set; }
    public decimal CurrentStock { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public ReorderConfig? ReorderConfig { get; set; }
    public List<StockTransaction> Transactions { get; set; } = new();
}