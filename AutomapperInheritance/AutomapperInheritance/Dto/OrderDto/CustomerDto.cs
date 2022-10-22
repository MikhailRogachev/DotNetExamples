namespace AutomapperInheritance.Dto.OrderDto
{
    public class CustomerDto
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public AddressDto AddressDelivery { get; set; }
        public ContactDto[] Contacts { get; set; }
    }
}
