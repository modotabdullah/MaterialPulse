namespace MaterialPulse.Domain.Entities;

public class PurchaseOrderItem
{
    public int Id { get; set; }
    public decimal QuantityOrdered { get; set; }
    public decimal UnitPrice { get; set; }

    public int PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; } = null!;

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;
}