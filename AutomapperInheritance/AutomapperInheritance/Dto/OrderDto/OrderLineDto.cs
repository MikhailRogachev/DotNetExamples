namespace AutomapperInheritance.Dto.OrderDto
{
    public class OrderLineDto
    {
        public string LineNumber { get; set; }
        public ProductDto[] Product { get; set; }
        public string CostCurrency { get; set; }
        public string PriceCurrency { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DealDto Deal { get; set; }
    }
}
 