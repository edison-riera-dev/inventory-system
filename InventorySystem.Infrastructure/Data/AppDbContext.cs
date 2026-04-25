using InventorySystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasIndex(p => p.SKU)
            .IsUnique();

        builder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Entity<Product>()
            .Property(p => p.SKU)
            .IsRequired()
            .HasMaxLength(80);

        builder.Entity<Product>()
            .Property(p => p.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);

        builder.Entity<StockMovement>()
            .HasOne(m => m.Product)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(m => m.ProductId);
    }
}