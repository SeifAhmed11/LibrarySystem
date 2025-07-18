using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Application.Services
{
    public class BookBorrowService : IBookBorrowService
    {
        private readonly IGenericRepository<BookBorrow> _bookBorrowRepository;
        private readonly IMapper _mapper;

        public BookBorrowService(IGenericRepository<BookBorrow> bookBorrowRepository, IMapper mapper)
        {
            _bookBorrowRepository = bookBorrowRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookBorrowDto>> GetAllBookBorrowsAsync()
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookBorrowDto>>(borrows);
        }

        public async Task<BookBorrowDto?> GetBookBorrowByIdAsync(int id)
        {
            var borrow = await _bookBorrowRepository.GetByIdAsync(id);
            return _mapper.Map<BookBorrowDto>(borrow);
        }

        public async Task<BookBorrowDto> CreateBookBorrowAsync(CreateBookBorrowDto createBookBorrowDto)
        {
            var borrow = _mapper.Map<BookBorrow>(createBookBorrowDto);
            var createdBorrow = await _bookBorrowRepository.AddAsync(borrow);
            return _mapper.Map<BookBorrowDto>(createdBorrow);
        }

        public async Task<BookBorrowDto> UpdateBookBorrowAsync(int id, UpdateBookBorrowDto updateBookBorrowDto)
        {
            var existingBorrow = await _bookBorrowRepository.GetByIdAsync(id);
            if (existingBorrow == null)
                throw new ArgumentException("Book borrow not found");

            _mapper.Map(updateBookBorrowDto, existingBorrow);
            await _bookBorrowRepository.UpdateAsync(existingBorrow);
            return _mapper.Map<BookBorrowDto>(existingBorrow);
        }

        public async Task DeleteBookBorrowAsync(int id)
        {
            var borrow = await _bookBorrowRepository.GetByIdAsync(id);
            if (borrow == null)
                throw new ArgumentException("Book borrow not found");

            await _bookBorrowRepository.DeleteAsync(borrow);
        }

        public async Task<IEnumerable<BookBorrowDto>> GetBorrowsByUserAsync(string userSSN)
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var userBorrows = borrows.Where(bb => bb.UserSSN == userSSN);
            return _mapper.Map<IEnumerable<BookBorrowDto>>(userBorrows);
        }

        public async Task<IEnumerable<BookBorrowDto>> GetBorrowsByBookAsync(int bookId)
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var bookBorrows = borrows.Where(bb => bb.BookId == bookId);
            return _mapper.Map<IEnumerable<BookBorrowDto>>(bookBorrows);
        }

        public async Task<IEnumerable<BookBorrowDto>> GetBorrowsByEmployeeAsync(int employeeId)
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var employeeBorrows = borrows.Where(bb => bb.EmployeeId == employeeId);
            return _mapper.Map<IEnumerable<BookBorrowDto>>(employeeBorrows);
        }

        public async Task<IEnumerable<BookBorrowDto>> GetOverdueBorrowsAsync()
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var overdueBorrows = borrows.Where(bb => bb.DueDate < DateTime.Now);
            return _mapper.Map<IEnumerable<BookBorrowDto>>(overdueBorrows);
        }

        public async Task<IEnumerable<BookBorrowDto>> GetBorrowsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var dateRangeBorrows = borrows.Where(bb => 
                bb.DateBorrowed >= startDate && bb.DateBorrowed <= endDate);
            return _mapper.Map<IEnumerable<BookBorrowDto>>(dateRangeBorrows);
        }
    }
} 