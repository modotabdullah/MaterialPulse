using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Domain.Entities;

public class ReorderAlert
{
    public int Id { get; set; }
    public DateOnly DateTriggered { get; set; }
    public AlertStatus Status { get; set; } = AlertStatus.Open;
    public decimal RecommendedQuantity { get; set; }

    public int MaterialId { get; set; }
    public Material Material { get; set; } = null!;
}