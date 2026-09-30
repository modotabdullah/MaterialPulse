namespace MaterialPulse.Domain.Entities;

public class ProductionRun
{
    public int Id { get; set; }
    public DateOnly RunDate { get; set; }
    public int QuantityProduced { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public List<StockTransaction> Transactions { get; set; } = new();
}