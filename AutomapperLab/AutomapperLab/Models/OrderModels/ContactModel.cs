namespace AutomapperLab.Models.OrderModels;
public class ContactModel
{
    public string Id { get; set; }
    public string ContactType { get; set; }
    public string Contact { get; set; }
    public string Description { get; set; }

    public CustomerModel Customer { get; set; }
}
