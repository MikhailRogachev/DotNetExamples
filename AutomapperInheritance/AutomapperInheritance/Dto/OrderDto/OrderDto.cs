namespace AutomapperInheritance.Dto.OrderDto
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public string CurrentStatus { get; set; }
        public string ResellerId { get; set; }
        public string CreatedDateTime { get; set; }
        public string LastUpdatedDateTime { get; set; }
        public CustomerDto Customer { get; set; }
        public OrderLineDto[] Lines { get; set; }
    }
}
