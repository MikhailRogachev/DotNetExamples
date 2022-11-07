using Microsoft.EntityFrameworkCore;
using ProductGrpc.Models;

namespace ProductGrpc.Data
{
    public class ProductsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ProductDb");
        }

        public DbSet<Product> Products { get; set; }
    }
}
