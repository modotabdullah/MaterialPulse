namespace MaterialPulse.Domain.Entities;

public class BomItem
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;

    public decimal QuantityPerUnit { get; set; }
}