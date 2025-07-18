using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookBorrowsController : ControllerBase
    {
        private readonly IBookBorrowService _bookBorrowService;

        public BookBorrowsController(IBookBorrowService bookBorrowService)
        {
            _bookBorrowService = bookBorrowService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetBookBorrows()
        {
            var borrows = await _bookBorrowService.GetAllBookBorrowsAsync();
            return Ok(borrows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookBorrowDto>> GetBookBorrow(int id)
        {
            var borrow = await _bookBorrowService.GetBookBorrowByIdAsync(id);
            if (borrow == null)
                return NotFound();

            return Ok(borrow);
        }

        [HttpPost]
        public async Task<ActionResult<BookBorrowDto>> CreateBookBorrow(CreateBookBorrowDto createBookBorrowDto)
        {
            try
            {
                var borrow = await _bookBorrowService.CreateBookBorrowAsync(createBookBorrowDto);
                return CreatedAtAction(nameof(GetBookBorrow), new { id = borrow.Id }, borrow);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookBorrow(int id, UpdateBookBorrowDto updateBookBorrowDto)
        {
            try
            {
                var borrow = await _bookBorrowService.UpdateBookBorrowAsync(id, updateBookBorrowDto);
                return Ok(borrow);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookBorrow(int id)
        {
            try
            {
                await _bookBorrowService.DeleteBookBorrowAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{userSSN}")]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetBorrowsByUser(string userSSN)
        {
            var borrows = await _bookBorrowService.GetBorrowsByUserAsync(userSSN);
            return Ok(borrows);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetBorrowsByBook(int bookId)
        {
            var borrows = await _bookBorrowService.GetBorrowsByBookAsync(bookId);
            return Ok(borrows);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetBorrowsByEmployee(int employeeId)
        {
            var borrows = await _bookBorrowService.GetBorrowsByEmployeeAsync(employeeId);
            return Ok(borrows);
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetOverdueBorrows()
        {
            var borrows = await _bookBorrowService.GetOverdueBorrowsAsync();
            return Ok(borrows);
        }

        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetBorrowsByDateRange(
            [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var borrows = await _bookBorrowService.GetBorrowsByDateRangeAsync(startDate, endDate);
            return Ok(borrows);
        }
    }
} 