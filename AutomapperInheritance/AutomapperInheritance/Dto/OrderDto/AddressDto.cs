using System.ComponentModel.DataAnnotations.Schema;

namespace AutomapperInheritance.Dto.OrderDto
{
    public class AddressDto
    {
        public string Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public string CustomerForeignKey { get; set; }

        [ForeignKey("CustomerForeignKey")]
        public CustomerDto Customer { get; set; }
    }
}
