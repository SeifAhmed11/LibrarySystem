namespace LibraryAPI.Application.DTOs
{
    public class EmployeeDto
    {
        public int EmpId { get; set; }
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? Bonus { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? HiringDate { get; set; }
        public EmployeeDto? Supervisor { get; set; }
        public FloorDto Floor { get; set; } = new FloorDto();
        public FloorDto? ManagedFloor { get; set; }
        public List<EmployeeDto> Subordinates { get; set; } = new List<EmployeeDto>();
        public List<UserDto> RegisteredUsers { get; set; } = new List<UserDto>();
        public List<BookBorrowDto> BookBorrows { get; set; } = new List<BookBorrowDto>();
    }

    public class CreateEmployeeDto
    {
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? Bonus { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? HiringDate { get; set; }
        public int? SupervisorId { get; set; }
        public int FloorId { get; set; }
        public int? ManagedFloorId { get; set; }
    }

    public class UpdateEmployeeDto
    {
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? Bonus { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? HiringDate { get; set; }
        public int? SupervisorId { get; set; }
        public int FloorId { get; set; }
        public int? ManagedFloorId { get; set; }
    }
} 