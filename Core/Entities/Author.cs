using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Core.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        // Navigation Properties
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
} 