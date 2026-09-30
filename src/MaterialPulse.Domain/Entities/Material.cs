using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Domain.Entities;

public class Material
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
    public UnitOfMeasure Unit { get; set; }
    public decimal CurrentStock { get; set; }
    public decimal ReorderPoint { get; set; }
    public decimal SafetyStock { get; set; }
    public decimal AvgDailyUsage { get; set; }
    public bool IsActive { get; set; } = true;

    public List<BomItem> BomItems { get; set; } = new();
    public List<SupplierMaterial> SupplierMaterials { get; set; } = new();
    public List<StockTransaction> Transactions { get; set; } = new();
    public List<ReorderAlert> ReorderAlerts { get; set; } = new();
    public List<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
}