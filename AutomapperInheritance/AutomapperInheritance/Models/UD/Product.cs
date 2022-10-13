using defProduct = AutomapperInheritance.Models;

namespace AutomapperInheritance.Models.UD
{
    public class Product : defProduct.Product
    {
        public new IReadOnlyCollection<Note> Notes { get; set; } = new List<Note>();
    }
}
