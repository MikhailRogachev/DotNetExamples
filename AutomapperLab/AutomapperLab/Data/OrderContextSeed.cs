using AutomapperLab.Contracts.Constants;
using AutomapperLab.Models.OrderModels;

namespace AutomapperLab.Data;

public class OrderContextSeed
{
    public static void ContentIni(OrderContext context)
    {
        if(!context.Order.Any())
        {
            context.Order.Add(GetOrderA());
            context.SaveChanges();
        }
    }

    private static OrderModel GetOrderA()
    {
        return new OrderModel
        {
            Id = "001",
            OrderNumber = "A001",
            CreatedDateTime = new DateTime(6000).ToString(AppConstants.DateTimeTemplate),
            LastUpdatedDateTime = new DateTime(6500).ToString(AppConstants.DateTimeTemplate),
            ResellerId = "70821234",
            CurrentStatus = "Active",
            Customer = new CustomerModel
            {
                Id = "1",
                CustomerId = "320045",
                CustomerName = "TMO SinCord",
                AddressDelivery = new AddressModel
                {
                    Id = "1",
                    Line1 = "23, CrossRoad",
                    Line2 = "Auto Building",
                    Line3 = String.Empty,
                    Region = "Eden",
                    City = "Auckland",
                    Country = "New Zealand",
                    PostCode = "6890"
                },
                Contacts = new ContactModel[]
                {
                    new ContactModel{ Id = "1", ContactType = "Email", Contact = "test@gora.com", Description = string.Empty },
                    new ContactModel{ Id = "2", ContactType = "DialNumber", Contact = "324-45-23", Description = string.Empty}
                }
            },
            Lines = new OrderLineModel[]
            {
                new OrderLineModel
                {
                    Id = "1",
                    LineNumber = "20010",
                    Product = new ProductModel[]
                    {
                        new ProductModel
                        {
                            Id = "1",
                            SourceId = "Storage",
                            ProductType = "Power Station",
                            ShortName = "PS ZXR - 500A-700",
                            FullName = "PS ZXR - 500A - 700, mini power station, 20M cord",
                            Manufacturer = "ZXR"                            
                        }
                    },
                    Cost = 1200.0M,
                    Price = 1630.0M,
                    CostCurrency = "EUR",
                    PriceCurrency = "EUR",
                    Quantity = 2,
                    Deal = new DealModel
                    {
                        DealId = "1",
                        StartDate = new DateTime(5900).ToString(AppConstants.DateTimeTemplate),
                        EndDate = new DateTime(7000).ToString(AppConstants.DateTimeTemplate),
                    }
                }
            }
        };
    }    
}