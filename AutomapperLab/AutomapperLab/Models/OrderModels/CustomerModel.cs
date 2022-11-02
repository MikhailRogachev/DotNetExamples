using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperLab.Models.OrderModels;
public class CustomerModel
{
    [Key]
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }

    // novigation properties
    [ForeignKey("Address")]
    public int AddressId { get; set; }
    public AddressModel Address { get; set; }
    public ICollection<ContactModel> Contacts { get; set; }
}
