using AutomapperLab.Models.OrderModels;

namespace AutomapperLab.Data
{
    public class CustomerContextSeed
    {
        public static void CustomerContextInitialize(CustomerContext context)
        {
            if(!context.Customer.Any())
            {
                SeedAddress(context);
                SeedCustomer(context);
                SeedContact(context);

                context.SaveChanges();
            }
        }

        public static void SeedCustomer(CustomerContext context)
        {
            context.Customer.Add(new CustomerModel
            {
                Id = 45,
                CustomerId = "320045",
                CustomerName = "TMO SinCord",
                AddressId = 1
            });

            context.Customer.Add(new CustomerModel
            {
                Id = 12,
                CustomerId = "20012",
                CustomerName = "Ascord",
                AddressId = 2
            });
        }

        public static void SeedAddress(CustomerContext context)
        {
            context.Address.Add(new AddressModel
            {
                Id = 1,
                Line1 = "23, CrossRoad",
                Line2 = "Auto Building",
                Line3 = string.Empty,
                Region = "Eden",
                City = "Auckland",
                Country = "New Zealand",
                PostCode = "6890"
            });

            context.Address.Add(new AddressModel
            {
                Id = 2,
                Line1 = "51/45, Kitchener rd.,",
                Line2 = "South Cross Bay",
                Line3 = "Blessing Community",
                Region = "South Cross",
                City = "Auckland",
                Country = "New Zealand",
                PostCode = "6834"
            });
        }

        public static void SeedContact(CustomerContext context)
        {
            context.Contact.Add(new ContactModel
            {
                Id = 1,
                ContactType = "Email",
                Contact = "adam_john@gora.com",
                Description = string.Empty,
                CustomerId = 45
            });

            context.Contact.Add(new ContactModel
            {
                Id = 2,
                ContactType = "DialNumber",
                Contact = "88-320-45-13",
                Description = string.Empty,
                CustomerId = 45
            });

            context.Contact.Add(new ContactModel
            {
                Id = 8,
                ContactType = "Email",
                Contact = "John.smith@abc.com",
                Description = string.Empty,
                CustomerId = 12
            });

            context.Contact.Add(new ContactModel
            {
                Id = 10,
                ContactType = "DialNumber",
                Contact = "420-417-50-23",
                Description = string.Empty,
                CustomerId = 12
            });            
        }
    }
}
