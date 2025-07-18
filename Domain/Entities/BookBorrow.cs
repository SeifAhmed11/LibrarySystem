using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Entities
{
    public class BookBorrow
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime DateBorrowed { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        [Required]
        public decimal AmountPaid { get; set; }
        
        // Navigation Properties
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        
        public string UserSSN { get; set; } = string.Empty;
        public User User { get; set; } = null!;
        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
} 