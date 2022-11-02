using AutomapperLab.Models.OrderModels;
using Microsoft.EntityFrameworkCore;

namespace AutomapperLab.Data
{
    public class CustomerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CustomerDb");
        }

        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<AddressModel> Address { get; set; }
    }
}
