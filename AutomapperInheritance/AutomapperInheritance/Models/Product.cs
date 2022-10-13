namespace AutomapperInheritance.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }        
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<Note> Notes { get; set; } = new List<Note>();
    }
}
