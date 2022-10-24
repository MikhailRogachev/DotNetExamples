namespace AutomapperInheritance.Dto.OrderDto
{
    public class ContactDto
    {
        public string Id { get; set; }
        public string ContactType { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
