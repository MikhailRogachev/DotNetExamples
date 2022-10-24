using AutomapperInheritance.Dto.OrderDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperInheritance.Data
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("OrderDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLineDto>()
                .HasOne(p => p.Order)
                .WithMany(p => p.Lines)
                .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<CustomerDto>()
                .HasOne(p => p.Order)
                .WithOne(p => p.Customer)
                .HasForeignKey<CustomerDto>(p => p.OrderId);

            modelBuilder.Entity<ProductDto>()
                .HasOne(p => p.Line)
                .WithMany(p => p.Product)
                .HasForeignKey(p => p.LineId);

            modelBuilder.Entity<DealDto>()
                .HasOne(p => p.Line)
                .WithOne(p => p.Deal)
                .HasForeignKey<DealDto>(p => p.LineId);

            modelBuilder.Entity<ContactDto>()
                .HasOne(p => p.Customer)
                .WithMany(p => p.Contacts);
        }

        public DbSet<OrderDto> Order { get; set; }
        public DbSet<CustomerDto> Customer { get; set; }
        public DbSet<ContactDto> Contact { get; set; }
        public DbSet<DealDto> Deal { get; set; }
        public DbSet<AddressDto> Address { get; set; }
        public DbSet<OrderLineDto> OrderLine { get; set; }
        public DbSet<ProductDto> Product { get; set; }
    }
}
