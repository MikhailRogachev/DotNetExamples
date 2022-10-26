namespace AutomapperLab.Models.OrderModels;
public class CustomerModel
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public AddressModel AddressDelivery { get; set; }
    public IReadOnlyCollection<ContactModel> Contacts { get; set; }

    public string OrderId { get; set; }
    public OrderModel Order { get; set; }
}
