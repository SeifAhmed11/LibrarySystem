using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Fname { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Lname { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public decimal Salary { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        public decimal? Bonus { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        
        // Navigation Properties
        public int? SupervisorId { get; set; }
        public Employee? Supervisor { get; set; }
        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        
        public int FloorId { get; set; }
        public Floor Floor { get; set; } = null!;
        
        public int? ManagedFloorId { get; set; }
        public Floor? ManagedFloor { get; set; }
        public DateTime? HiringDate { get; set; }
        
        public ICollection<User> RegisteredUsers { get; set; } = new List<User>();
        public ICollection<BookBorrow> BookBorrows { get; set; } = new List<BookBorrow>();
    }
} 