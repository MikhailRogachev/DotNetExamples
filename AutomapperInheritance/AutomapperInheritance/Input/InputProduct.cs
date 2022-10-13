namespace AutomapperInheritance.Input
{
    public class InputProduct
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = "Main";
        public string Name { get; set; }
        public string Description { get; set; }
        public string Storage { get; set; }
        public string Manufacturer { get; set; }
        public string Vendor { get; set; }
        public string LocalVendor { get; set; }
        public bool IsActive { get; set; }
    }
}
