using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        // Navigation Properties
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
} 