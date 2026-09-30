using MaterialPulse.Domain.Entities;
using MaterialPulse.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using MaterialPulse.Application.Common;

namespace MaterialPulse.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<BomItem> BomItems => Set<BomItem>();
    public DbSet<SupplierMaterial> SupplierMaterials => Set<SupplierMaterial>();
    public DbSet<ProductionRun> ProductionRuns => Set<ProductionRun>();
    public DbSet<StockTransaction> StockTransactions => Set<StockTransaction>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();
    public DbSet<ReorderAlert> ReorderAlerts => Set<ReorderAlert>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 3);
        configurationBuilder.Properties<UnitOfMeasure>().HaveConversion<string>().HaveMaxLength(30);
        configurationBuilder.Properties<TransactionType>().HaveConversion<string>().HaveMaxLength(30);
        configurationBuilder.Properties<PurchaseOrderStatus>().HaveConversion<string>().HaveMaxLength(30);
        configurationBuilder.Properties<AlertStatus>().HaveConversion<string>().HaveMaxLength(30);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BomItem>().HasKey(b => new { b.ProductId, b.MaterialId });
        modelBuilder.Entity<SupplierMaterial>().HasKey(s => new { s.SupplierId, s.MaterialId });

        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<Supplier>().Property(s => s.Name).IsRequired().HasMaxLength(150);

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(m => m.Name).IsRequired().HasMaxLength(150);
            entity.HasIndex(m => m.Name).IsUnique();
        });

        modelBuilder.Entity<StockTransaction>()
            .HasIndex(t => new { t.MaterialId, t.TransactionDate });

        modelBuilder.Entity<PurchaseOrderItem>()
            .Property(i => i.UnitPrice).HasPrecision(18, 2);

        foreach (var fk in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}