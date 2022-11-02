using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperLab.Models.OrderModels;
public class OrderLineModel
{
    [Key]
    public int Id { get; set; }
    public string LineNumber { get; set; }
    public string CostCurrency { get; set; }
    public string PriceCurrency { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    // novigation properties
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public ProductModel Product { get; set; }

    [ForeignKey("Deal")]
    public int DealId { get; set; }
    public DealModel Deal { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public OrderModel Order { get; set; }
}
  