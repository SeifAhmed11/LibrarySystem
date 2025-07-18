using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Entities
{
    public class Shelf
    {
        [Key]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;
        
        // Navigation Properties
        public int FloorNumber { get; set; }
        public Floor Floor { get; set; } = null!;
        
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
} 