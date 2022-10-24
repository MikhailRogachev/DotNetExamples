namespace AutomapperInheritance.Dto.OrderDto
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public AddressDto AddressDelivery { get; set; }
        public ContactDto[] Contacts { get; set; }

        public string OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
