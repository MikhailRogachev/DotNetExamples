using System.ComponentModel.DataAnnotations;

namespace AutomapperLab.Models.OrderModels;
public class DealModel
{
    [Key]
    public string DealId { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public decimal Percent { get; set; }

    public string LineId { get; set; }
    public OrderLineModel Line { get; set; }
}
