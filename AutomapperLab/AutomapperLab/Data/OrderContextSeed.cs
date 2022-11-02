using AutomapperLab.Contracts.Constants;
using AutomapperLab.Models.OrderModels;

namespace AutomapperLab.Data;

public class OrderContextSeed
{
    public static void Seed(OrderContext context)
    {
        if (!context.Order.Any())
        {
            SeedDeals(context);
            SeedProduct(context);
            SeedOrderLines(context);
            SeedContacts(context);
            SeedAddresses(context);
            SeedCustomers(context);
            SeedOrder(context);

            context.SaveChanges();
        }
    }

    private static void SeedOrder(OrderContext context)
    {
        context.Order.Add(new OrderModel
        {
            Id = 1,
            OrderNumber = "A-001",
            OrderType = "A",
            CreatedDateTime = new DateTime(16800),
            LastUpdatedDateTime = new DateTime(16950),
            ResellerId = "70821234",
            CurrentStatus = "Active",
            CustomerId = 45
        });

        context.Order.Add(new OrderModel
        {
            Id = 2,
            OrderNumber = "B-4001",
            OrderType = "B",
            CreatedDateTime = new DateTime(6340),
            LastUpdatedDateTime = new DateTime(6500),
            ResellerId = "80821240",
            CurrentStatus = "Active",
            CustomerId = 12
        });
    }

    private static void SeedCustomers(OrderContext context)
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

    private static void SeedAddresses(OrderContext context)
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

    private static void SeedContacts(OrderContext context)
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

    private static void SeedOrderLines(OrderContext context)
    {
        context.OrderLine.Add(new OrderLineModel
        {
            Id = 1,
            LineNumber = "20010",
            Cost = 1200.0M,
            Price = 1630.0M,
            CostCurrency = "EUR",
            PriceCurrency = "EUR",
            Quantity = 2,
            ProductId = 1,
            DealId = 4,
            OrderId = 1
        });

        context.OrderLine.Add(new OrderLineModel
        {
            Id = 2,
            LineNumber = "4001",
            Cost = 3700.0M,
            Price = 4630.0M,
            CostCurrency = "EUR",
            PriceCurrency = "EUR",
            Quantity = 1,
            ProductId = 15,
            DealId = 4,
            OrderId = 1
        });

        context.OrderLine.Add(new OrderLineModel
        {
            Id = 15,
            LineNumber = "122324",
            Cost = 300.0M,
            Price = 460.0M,
            CostCurrency = "EUR",
            PriceCurrency = "EUR",
            Quantity = 3,
            ProductId = 13,
            DealId = 8,
            OrderId = 2
        });
    }

    private static void SeedProduct(OrderContext context)
    {
        context.Product.Add(new ProductModel
        {
            Id = 1,
            SourceId = "Storage",
            ProductType = "Power Station",
            ShortName = "PS ZXR - 500A-700",
            FullName = "PS ZXR - 500A - 700, mini power station, 20M cord",
            Manufacturer = "ZXR"
        });

        context.Product.Add(new ProductModel
        {
            Id = 15,
            SourceId = "Storage",
            ProductType = "Mobile",
            ShortName = "Sony MMX-89009 Pro",
            FullName = "Sony MMX-89009 Pro, black color, metal, 2X2 Camera",
            Manufacturer = "Sony"
        });

        context.Product.Add(new ProductModel
        {
            Id = 13,
            SourceId = "eShop",
            ProductType = "Accessories",
            ShortName = "Sony Phone-Bag",
            FullName = "Sony Phone-Bag: Sony MMX-89009 Pro, Sony MMX-89013 Pro, Sony MMX-89010 Pro",
            Manufacturer = "Sony"
        });
    }

    private static void SeedDeals(OrderContext context)
    {
        context.Deal.Add(new DealModel
        {
            DealId = 4,
            StartDate = new DateTime(15900),
            EndDate = new DateTime(17000),
            Percent = 15
        });

        context.Deal.Add(new DealModel 
        {
            DealId = 8,
            StartDate = new DateTime(25900),
            EndDate = new DateTime(27000),
            Percent = 5
        });
    }

}