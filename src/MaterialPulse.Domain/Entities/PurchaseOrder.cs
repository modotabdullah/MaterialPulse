using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Domain.Entities;

public class PurchaseOrder
{
    public int Id { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly? ExpectedDelivery { get; set; }
    public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
    public string? UserId { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public List<PurchaseOrderItem> Items { get; set; } = new();
}