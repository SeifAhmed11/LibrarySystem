using LibraryAPI.Application.DTOs;

namespace LibraryAPI.Application.Interfaces
{
    public interface IBookBorrowService
    {
        Task<IEnumerable<BookBorrowDto>> GetAllBookBorrowsAsync();
        Task<BookBorrowDto?> GetBookBorrowByIdAsync(int id);
        Task<BookBorrowDto> CreateBookBorrowAsync(CreateBookBorrowDto createBookBorrowDto);
        Task<BookBorrowDto> UpdateBookBorrowAsync(int id, UpdateBookBorrowDto updateBookBorrowDto);
        Task DeleteBookBorrowAsync(int id);
        Task<IEnumerable<BookBorrowDto>> GetBorrowsByUserAsync(string userSSN);
        Task<IEnumerable<BookBorrowDto>> GetBorrowsByBookAsync(int bookId);
        Task<IEnumerable<BookBorrowDto>> GetBorrowsByEmployeeAsync(int employeeId);
        Task<IEnumerable<BookBorrowDto>> GetOverdueBorrowsAsync();
        Task<IEnumerable<BookBorrowDto>> GetBorrowsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 