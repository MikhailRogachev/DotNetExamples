using AutomapperInheritance.Contracts.Constants;
using AutomapperInheritance.Dto.OrderDto;

namespace AutomapperInheritance.Data
{
    public class OrderContextSeed
    {
        public static void ContectIni(OrderContext context)
        {
            DealSeed(context);
            ProductSeed(context);
        }

        private static void ProductSeed(OrderContext context) 
        {
            if(!context.Product.Any())
            {
                context.Product.Add(
                    new ProductDto
                    {
                        Id = "PR001",
                        SourceId = "eShop",
                        ShortName = "Power Station Z09",
                        FullName = "Power station Z09 ORNIX, mini flag, cord inclusion",
                        Manufacturer = "ORNIX",
                        ProductType = "Equipment"
                    });

                context.Product.Add(
                    new ProductDto
                    {
                        Id = "Z0010890",
                        SourceId = "Storage",
                        ShortName = "Power Station Z09",
                        FullName = "Power station Z09 ORNIX, mini flag, cord inclusion",
                        Manufacturer = "ORNIX",
                        ProductType = "Equipment"
                    });

                context.Product.Add(
                    new ProductDto
                    {
                        Id = "A0010890",
                        SourceId = "Storage",
                        ShortName = "Fuss Arg 015",
                        FullName = "Fuss Arg 15A, ceramic, 12X5",
                        Manufacturer = "ORNIX",
                        ProductType = "Material"
                    });
            }
        }

        private static void DealSeed(OrderContext context)
        {
            if(!context.Deal.Any())
            {
                context.Deal.Add(
                    new DealDto
                    {
                        DealId = "0001",
                        StartDate = (new DateTime(7000)).ToString(AppConstants.DateTimeTemplate),
                        EndDate = (new DateTime(8000)).ToString(AppConstants.DateTimeTemplate),
                        Percent = 15.5M
                    });

                context.Deal.Add(
                    new DealDto
                    {
                        DealId = "0002",
                        StartDate = (new DateTime(7500)).ToString(AppConstants.DateTimeTemplate),
                        EndDate = (new DateTime(8000)).ToString(AppConstants.DateTimeTemplate),
                        Percent = 16M
                    });

                context.Deal.Add(
                    new DealDto
                    {
                        DealId = "0003",
                        StartDate = (new DateTime(8500)).ToString(AppConstants.DateTimeTemplate),
                        EndDate = (new DateTime(10000)).ToString(AppConstants.DateTimeTemplate),
                        Percent = 12M
                    });

                context.SaveChanges();
            }
        }
    }
}