namespace AutomapperLab.Models.OrderModels;
public class OrderModel
{
    public string Id { get; set; }
    public string OrderNumber { get; set; }
    public string CurrentStatus { get; set; }
    public string ResellerId { get; set; }
    public string CreatedDateTime { get; set; }
    public string LastUpdatedDateTime { get; set; }
    public CustomerModel Customer { get; set; }
    public IReadOnlyCollection<OrderLineModel> Lines { get; set; }
}
