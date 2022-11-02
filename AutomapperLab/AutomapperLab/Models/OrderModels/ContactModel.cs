using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperLab.Models.OrderModels;
public class ContactModel
{
    [Key]
    public int Id { get; set; }
    public string ContactType { get; set; }
    public string Contact { get; set; }
    public string Description { get; set; }

    // novigation properties

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
}
