using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Core.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        // Navigation Properties
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;
        
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        
        public string ShelfCode { get; set; } = string.Empty;
        public Shelf Shelf { get; set; } = null!;
        
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookBorrow> BookBorrows { get; set; } = new List<BookBorrow>();
    }
} 