using MaterialPulse.Domain.Enums;

namespace MaterialPulse.Application.Inventory;

public record StockItemDto(
    int Id,
    string Name,
    string? Category,
    UnitOfMeasure Unit,
    decimal CurrentStock,
    decimal ReorderPoint,
    bool IsLow);