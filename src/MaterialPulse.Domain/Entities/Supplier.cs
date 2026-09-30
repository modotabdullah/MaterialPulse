namespace MaterialPulse.Domain.Entities;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ContactNumber { get; set; }
    public double OnTimeDeliveryRate { get; set; }
    public double AvgDeliveryTimeDays { get; set; }
    public double Rating { get; set; }
    public bool IsActive { get; set; } = true;

    public List<SupplierMaterial> SupplierMaterials { get; set; } = new();
    public List<PurchaseOrder> PurchaseOrders { get; set; } = new();
}