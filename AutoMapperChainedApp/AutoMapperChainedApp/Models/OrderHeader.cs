namespace AutoMapperChainedApp.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string OrderType { get; set; }
        public string ResellerId { get; set; }
        public Customer Customer { get; set; }
        public string StatusId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public IList<OrderLine> Lines { get; set; }
    }
}
