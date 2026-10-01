using MaterialPulse.Domain.Entities;
using MaterialPulse.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MaterialPulse.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.Materials.AnyAsync())
        {
            return;
        }

        var supplierA = new Supplier
        {
            Name = "Barishal Paper Traders",
            ContactNumber = "01700000001",
            OnTimeDeliveryRate = 92,
            AvgDeliveryTimeDays = 3,
            Rating = 4.2
        };

        var supplierB = new Supplier
        {
            Name = "Delta Chemicals",
            ContactNumber = "01700000002",
            OnTimeDeliveryRate = 85,
            AvgDeliveryTimeDays = 5,
            Rating = 3.8
        };

        var board = new Material { Name = "Corrugated Board", Category = "Paper", Unit = UnitOfMeasure.Sheet, CurrentStock = 5000, ReorderPoint = 1500, SafetyStock = 500, AvgDailyUsage = 300 };
        var kraft = new Material { Name = "Kraft Paper", Category = "Paper", Unit = UnitOfMeasure.Roll, CurrentStock = 120, ReorderPoint = 40, SafetyStock = 15, AvgDailyUsage = 8 };
        var adhesive = new Material { Name = "Starch Adhesive", Category = "Chemical", Unit = UnitOfMeasure.Kilogram, CurrentStock = 800, ReorderPoint = 250, SafetyStock = 100, AvgDailyUsage = 40 };
        var ink = new Material { Name = "Printing Ink", Category = "Chemical", Unit = UnitOfMeasure.Liter, CurrentStock = 35, ReorderPoint = 50, SafetyStock = 20, AvgDailyUsage = 5 };
        var wire = new Material { Name = "Stitching Wire", Category = "Metal", Unit = UnitOfMeasure.Kilogram, CurrentStock = 200, ReorderPoint = 60, SafetyStock = 25, AvgDailyUsage = 6 };
        var tape = new Material { Name = "Packing Tape", Category = "Accessory", Unit = UnitOfMeasure.Roll, CurrentStock = 300, ReorderPoint = 100, SafetyStock = 40, AvgDailyUsage = 12 };

        var cartonBox = new Product { Name = "Component Carton Box", Description = "Corrugated carton for electronic components" };
        var displayBox = new Product { Name = "Printed Display Box", Description = "Printed kraft box for retail packaging" };

        db.Suppliers.AddRange(supplierA, supplierB);
        db.Materials.AddRange(board, kraft, adhesive, ink, wire, tape);
        db.Products.AddRange(cartonBox, displayBox);

        db.SupplierMaterials.AddRange(
            new SupplierMaterial { Supplier = supplierA, Material = board },
            new SupplierMaterial { Supplier = supplierA, Material = kraft },
            new SupplierMaterial { Supplier = supplierA, Material = tape },
            new SupplierMaterial { Supplier = supplierB, Material = adhesive },
            new SupplierMaterial { Supplier = supplierB, Material = ink },
            new SupplierMaterial { Supplier = supplierB, Material = wire });

        db.BomItems.AddRange(
            new BomItem { Product = cartonBox, Material = board, QuantityPerUnit = 1 },
            new BomItem { Product = cartonBox, Material = adhesive, QuantityPerUnit = 0.05m },
            new BomItem { Product = cartonBox, Material = wire, QuantityPerUnit = 0.02m },
            new BomItem { Product = displayBox, Material = kraft, QuantityPerUnit = 0.2m },
            new BomItem { Product = displayBox, Material = ink, QuantityPerUnit = 0.01m });

        await db.SaveChangesAsync();
    }
}