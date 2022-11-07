using ProductGrpc.Enums;
using ProductGrpc.Models;

namespace ProductGrpc.Data
{
    public static class ProductsContextSeed
    {
        public static void Seed(ProductsContext productContext)
        {
            if(!productContext.Products.Any())
            {
                var productsList = new List<Product>
                {
                    new Product
                    {
                        ProductId = 1,
                        Name = "Mi10T",
                        Description = "New Xiaomi Phone Mi10T",
                        Price = 699,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "P40",
                        Description = "New Xiaomi Phone P40",
                        Price = 899,
                        Status = ProductStatus.LOW,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "A50",
                        Description = "New Samsung Phone A50",
                        Price = 399,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                };

                productContext.Products.AddRange(productsList);
                productContext.SaveChanges();
            }
        }
    }
}
