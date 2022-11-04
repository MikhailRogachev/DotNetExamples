namespace AutoMapperChainedApp.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string LineNumber { get; set; }
        public IList<Product> Products { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public Deal Deal { get; set; }
    }
}
