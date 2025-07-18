using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Core.Entities
{
    public class User
    {
        [Key]
        [MaxLength(20)]
        public string SSN { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        
        // Navigation Properties
        public int RegisteredByEmployeeId { get; set; }
        public Employee RegisteredByEmployee { get; set; } = null!;
        
        public ICollection<BookBorrow> BookBorrows { get; set; } = new List<BookBorrow>();
    }
} 