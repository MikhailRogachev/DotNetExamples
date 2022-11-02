using AutomapperLab.Data;

namespace AutomapperLabTests.Data
{
    public class CustomerSeedTests
    {
        public static CustomerContext Context()
        {
            var context = new CustomerContext();
            CustomerContextSeed.CustomerContextInitialize(context);

            return context;
        }

        [Fact]
        public void AddressDb_Test()
        {
            var adressDb = Context().Address;

            Assert.True(adressDb.Any());
            Assert.Equal(2, adressDb.Count());
            Assert.NotNull(adressDb.FirstOrDefault(p => p.Id == 1));
            Assert.NotNull(adressDb.FirstOrDefault(p => p.Id == 2));
        }

        [Fact]
        public void CustomerDb_Test()
        {
            var customerDb = Context().Customer;

            Assert.True(customerDb.Any());
            Assert.Equal(2, customerDb.Count());
            Assert.NotNull(customerDb.FirstOrDefault(p => p.Id == 45));
            Assert.NotNull(customerDb.FirstOrDefault(p => p.Id == 12));
        }
    }
}
