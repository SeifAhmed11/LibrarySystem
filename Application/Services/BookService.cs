using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<BookAuthor> _bookAuthorRepository;
        private readonly IGenericRepository<BookBorrow> _bookBorrowRepository;
        private readonly IGenericRepository<Shelf> _shelfRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> bookRepository,
                          IGenericRepository<BookAuthor> bookAuthorRepository,
                          IGenericRepository<BookBorrow> bookBorrowRepository,
                          IGenericRepository<Shelf> shelfRepository,
                          IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _bookBorrowRepository = bookBorrowRepository;
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDetailDto?> GetBookDetailsByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return null;

            return _mapper.Map<BookDetailDto>(book);
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            var createdBook = await _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(createdBook);
        }

        public async Task<BookDto> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
                throw new ArgumentException("Book not found");

            _mapper.Map(updateBookDto, existingBook);
            await _bookRepository.UpdateAsync(existingBook);
            return _mapper.Map<BookDto>(existingBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new ArgumentException("Book not found");

            await _bookRepository.DeleteAsync(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(int authorId)
        {
            var bookAuthors = await _bookAuthorRepository.GetAllAsync();
            var bookIds = bookAuthors.Where(ba => ba.AuthorId == authorId).Select(ba => ba.BookId);
            
            var books = await _bookRepository.GetAllAsync();
            var authorBooks = books.Where(b => bookIds.Contains(b.Id));
            return _mapper.Map<IEnumerable<BookDto>>(authorBooks);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByPublisherAsync(int publisherId)
        {
            var books = await _bookRepository.GetAllAsync();
            var publisherBooks = books.Where(b => b.PublisherId == publisherId);
            return _mapper.Map<IEnumerable<BookDto>>(publisherBooks);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByCategoryAsync(int categoryId)
        {
            var books = await _bookRepository.GetAllAsync();
            var categoryBooks = books.Where(b => b.CategoryId == categoryId);
            return _mapper.Map<IEnumerable<BookDto>>(categoryBooks);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByShelfAsync(string shelfCode)
        {
            var books = await _bookRepository.GetAllAsync();
            var shelfBooks = books.Where(b => b.ShelfCode == shelfCode);
            return _mapper.Map<IEnumerable<BookDto>>(shelfBooks);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByFloorAsync(int floorNumber)
        {
            var shelves = await _shelfRepository.GetAllAsync();
            var floorShelfCodes = shelves.Where(s => s.FloorNumber == floorNumber).Select(s => s.Code);
            
            var books = await _bookRepository.GetAllAsync();
            var floorBooks = books.Where(b => floorShelfCodes.Contains(b.ShelfCode));
            return _mapper.Map<IEnumerable<BookDto>>(floorBooks);
        }

        public async Task<IEnumerable<BookDto>> GetOverdueBooksAsync()
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var overdueBorrows = borrows.Where(bb => bb.DueDate < DateTime.Now);
            var overdueBookIds = overdueBorrows.Select(bb => bb.BookId).Distinct();
            
            var books = await _bookRepository.GetAllAsync();
            var overdueBooks = books.Where(b => overdueBookIds.Contains(b.Id));
            return _mapper.Map<IEnumerable<BookDto>>(overdueBooks);
        }

        public async Task<IEnumerable<BookDto>> SearchBooksAsync(string searchTerm)
        {
            var books = await _bookRepository.GetAllAsync();
            var searchResults = books.Where(b => 
                b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<IEnumerable<BookDto>>(searchResults);
        }
    }
} 