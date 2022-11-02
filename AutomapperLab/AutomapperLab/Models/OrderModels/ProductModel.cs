using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperLab.Models.OrderModels;
public class ProductModel
{
    [Key]
    public int Id { get; set; }
    public string SourceId { get; set; }
    public string ProductType { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Manufacturer { get; set; }

    // novigation properties
    public ICollection<OrderLineModel> Lines { get; set; }
}
