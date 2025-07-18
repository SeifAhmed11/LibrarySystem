namespace LibraryAPI.Application.DTOs
{
    public class BookBorrowDto
    {
        public int Id { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountPaid { get; set; }
        public BookDto Book { get; set; } = new BookDto();
        public UserDto User { get; set; } = new UserDto();
        public EmployeeDto Employee { get; set; } = new EmployeeDto();
        public bool IsOverdue => DateTime.Now > DueDate;
    }

    public class CreateBookBorrowDto
    {
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountPaid { get; set; }
        public int BookId { get; set; }
        public string UserSSN { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
    }

    public class UpdateBookBorrowDto
    {
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountPaid { get; set; }
        public int BookId { get; set; }
        public string UserSSN { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
    }
} 