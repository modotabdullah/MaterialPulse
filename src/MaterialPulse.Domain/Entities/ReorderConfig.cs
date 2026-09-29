namespace MaterialPulse.Domain.Entities;

public class ReorderConfig
{
    public int Id { get; set; }
    public decimal ReorderLevel { get; set; }
    public decimal SafetyStock { get; set; }
    public decimal ReorderQuantity { get; set; }
    public int LeadTimeDays { get; set; }

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;
}