namespace AutomapperInheritance.Dto.OrderDto
{
    public class OrderLineDto
    {
        public string Id { get; set; }
        public string LineNumber { get; set; }
        public ProductDto[] Product { get; set; }
        public string CostCurrency { get; set; }
        public string PriceCurrency { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DealDto Deal { get; set; }

        public string OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
 