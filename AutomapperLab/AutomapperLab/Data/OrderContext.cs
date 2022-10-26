using AutomapperLab.Models.OrderModels;
using Microsoft.EntityFrameworkCore;

namespace AutomapperLab.Data;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("OrderDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderLineModel>()
            .HasOne(p => p.Order)
            .WithMany(p => p.Lines)
            .HasForeignKey(p => p.OrderId);

        modelBuilder.Entity<CustomerModel>()
            .HasOne(p => p.Order)
            .WithOne(p => p.Customer)
            .HasForeignKey<CustomerModel>(p => p.OrderId);

        modelBuilder.Entity<ProductModel>()
            .HasOne(p => p.Line)
            .WithMany(p => p.Product)
            .HasForeignKey(p => p.LineId);

        modelBuilder.Entity<DealModel>()
            .HasOne(p => p.Line)
            .WithOne(p => p.Deal)
            .HasForeignKey<DealModel>(p => p.LineId);

        modelBuilder.Entity<ContactModel>()
            .HasOne(p => p.Customer)
            .WithMany(p => p.Contacts);
    }

    public DbSet<OrderModel> Order { get; set; }
    public DbSet<CustomerModel> Customer { get; set; }
    public DbSet<ContactModel> Contact { get; set; }
    public DbSet<DealModel> Deal { get; set; }
    public DbSet<AddressModel> Address { get; set; }
    public DbSet<OrderLineModel> OrderLine { get; set; }
    public DbSet<ProductModel> Product { get; set; }
}
