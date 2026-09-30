namespace MaterialPulse.Domain.Entities;

public class SupplierMaterial
{
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;
}