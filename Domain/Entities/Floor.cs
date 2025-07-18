using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Entities
{
    public class Floor
    {
        [Key]
        public int FloorNumber { get; set; }
        
        [Required]
        public int NumberOfBlocks { get; set; }
        
        // Navigation Properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public Employee? Manager { get; set; }
        public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
} 