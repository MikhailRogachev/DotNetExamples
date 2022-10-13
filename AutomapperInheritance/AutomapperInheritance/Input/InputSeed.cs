namespace AutomapperInheritance.Input
{
    public static class InputSeed
    {

        public static List<InputProduct> GetProductsCollection()
        {
            return new List<InputProduct>()
            {
                new InputProduct
                {
                    Id = 1,
                    ProductType = "Main",
                    Name = "Family Product",
                    Description = "Family product to use on the local villiage.",
                    IsActive = true,
                    LocalVendor = "Shop 1",
                    Vendor = "Rose Geers",
                    Manufacturer = "Rebook",
                    Storage = "1001"
                },
                new InputProduct
                {
                    Id = 1,
                    ProductType = "IN",
                    Name = "Product new type",
                    Description = "This product was never used before",
                    IsActive = true,
                    LocalVendor = "Shop 12",
                    Vendor = "Rose Geers",
                    Manufacturer = "Julia",
                    Storage = "1002"
                }
            };
        }

        public static Type GetProductType(this InputProduct obj)
        {
            if (obj.ProductType == "IN")
                return typeof(Models.IN.Product);
            else if (obj.ProductType == "UD")
                return typeof(Models.UD.Product);
            else
                return typeof(Models.Product);
        }
    }
}
