namespace MaterialPulse.Application.Inventory;

public interface IInventoryService
{
    Task<List<StockItemDto>> GetStockListAsync();
    Task RecordStockInAsync(int materialId, decimal quantity, string? source, string? userId);
    Task RecordConsumptionAsync(int materialId, decimal quantity, string? destination, string? userId, int? productionRunId = null);
}