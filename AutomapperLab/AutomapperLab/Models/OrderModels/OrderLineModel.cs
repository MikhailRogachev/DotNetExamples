namespace AutomapperLab.Models.OrderModels;
public class OrderLineModel
{
    public string Id { get; set; }
    public string LineNumber { get; set; }
    public IReadOnlyCollection<ProductModel> Product { get; set; }
    public string CostCurrency { get; set; }
    public string PriceCurrency { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public DealModel Deal { get; set; }
    public string OrderId { get; set; }
    public OrderModel Order { get; set; }
}
  