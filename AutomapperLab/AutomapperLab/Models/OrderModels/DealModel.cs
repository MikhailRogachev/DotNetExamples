using System.ComponentModel.DataAnnotations;

namespace AutomapperLab.Models.OrderModels;
public class DealModel
{
    [Key]
    public int DealId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Percent { get; set; }
    
    // novigation properties
    public ICollection<OrderLineModel> Line { get; set; }
}
