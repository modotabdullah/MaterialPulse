using MaterialPulse.Application.Common;
using MaterialPulse.Domain.Entities;
using MaterialPulse.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MaterialPulse.Application.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IApplicationDbContext _db;

    public InventoryService(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<StockItemDto>> GetStockListAsync()
    {
        return await _db.Materials
            .Where(m => m.IsActive)
            .OrderBy(m => m.Name)
            .Select(m => new StockItemDto(
                m.Id,
                m.Name,
                m.Category,
                m.Unit,
                m.CurrentStock,
                m.ReorderPoint,
                m.CurrentStock <= m.ReorderPoint))
            .ToListAsync();
    }

    public async Task RecordStockInAsync(int materialId, decimal quantity, string? source, string? userId)
    {
        var material = await GetActiveMaterialAsync(materialId);
        ValidateQuantity(quantity);

        material.CurrentStock += quantity;
        AddTransaction(material, TransactionType.StockIn, quantity, source, userId, null);

        await _db.SaveChangesAsync();
    }

    public async Task RecordConsumptionAsync(int materialId, decimal quantity, string? destination, string? userId, int? productionRunId = null)
    {
        var material = await GetActiveMaterialAsync(materialId);
        ValidateQuantity(quantity);

        if (quantity > material.CurrentStock)
        {
            throw new InvalidOperationException(
                $"Not enough stock. Available: {material.CurrentStock}, requested: {quantity}.");
        }

        material.CurrentStock -= quantity;
        AddTransaction(material, TransactionType.Consumption, quantity, destination, userId, productionRunId);

        await _db.SaveChangesAsync();
    }

    private async Task<Material> GetActiveMaterialAsync(int materialId)
    {
        var material = await _db.Materials.FirstOrDefaultAsync(m => m.Id == materialId && m.IsActive);

        if (material is null)
        {
            throw new InvalidOperationException("Material not found.");
        }

        return material;
    }

    private static void ValidateQuantity(decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }
    }

    private void AddTransaction(Material material, TransactionType type, decimal quantity, string? sourceDestination, string? userId, int? productionRunId)
    {
        _db.StockTransactions.Add(new StockTransaction
        {
            Material = material,
            Type = type,
            Quantity = quantity,
            SourceDestination = sourceDestination,
            UserId = userId,
            ProductionRunId = productionRunId,
            TransactionDate = DateTime.UtcNow
        });
    }
}