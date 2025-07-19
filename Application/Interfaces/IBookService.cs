using LibraryAPI.Application.DTOs;

namespace LibraryAPI.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDetailDto?> GetBookDetailsByIdAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto> UpdateBookAsync(int id, UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id); 
        Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<BookDto>> GetBooksByPublisherAsync(int publisherId);
        Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<BookDto>> GetBooksByShelfAsync(string shelfCode);
        Task<IEnumerable<BookDto>> GetBooksByFloorAsync(int floorNumber);
        Task<IEnumerable<BookDto>> GetOverdueBooksAsync();
        Task<IEnumerable<BookDto>> SearchBooksAsync(string searchTerm);
    }
} 