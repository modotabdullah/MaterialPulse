namespace MaterialPulse.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public List<BomItem> BomItems { get; set; } = new();
    public List<ProductionRun> ProductionRuns { get; set; } = new();
}