using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperLab.Models.OrderModels;
public class OrderModel
{
    [Key]
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public string OrderType { get; set; }
    public string CurrentStatus { get; set; }
    public string ResellerId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime LastUpdatedDateTime { get; set; }

    // novigation properties
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
    public ICollection<OrderLineModel> Lines { get; set; }
}
