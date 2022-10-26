namespace AutomapperLab.Models.OrderModels;
public class ProductModel
{
    public string Id { get; set; }
    public string SourceId { get; set; }
    public string ProductType { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Manufacturer { get; set; }

    public string LineId { get; set; }
    public OrderLineModel Line { get; set; }
}
