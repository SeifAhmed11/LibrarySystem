namespace LibraryAPI.Application.DTOs
{
    public class UserDto
    {
        public string SSN { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public EmployeeDto RegisteredByEmployee { get; set; } = new EmployeeDto();
        public List<BookBorrowDto> BookBorrows { get; set; } = new List<BookBorrowDto>();
    }

    public class CreateUserDto
    {
        public string SSN { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RegisteredByEmployeeId { get; set; }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RegisteredByEmployeeId { get; set; }
    }
} 