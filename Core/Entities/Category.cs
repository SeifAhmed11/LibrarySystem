using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string CatName { get; set; } = string.Empty;
        
        // Navigation Properties
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
} 