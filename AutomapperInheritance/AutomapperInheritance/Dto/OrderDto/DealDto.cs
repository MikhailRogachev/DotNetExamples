using System.ComponentModel.DataAnnotations;

namespace AutomapperInheritance.Dto.OrderDto
{
    public class DealDto
    {
        [Key]
        public string DealId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Percent { get; set; }

        public string LineId { get; set; }
        public OrderLineDto Line { get; set; }
    }
}
