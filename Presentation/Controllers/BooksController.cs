using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<BookDetailDto>> GetBookDetails(int id)
        {
            var book = await _bookService.GetBookDetailsByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
        {
            try
            {
                var book = await _bookService.CreateBookAsync(createBookDto);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            try
            {
                var book = await _bookService.UpdateBookAsync(id, updateBookDto);
                return Ok(book);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthor(int authorId)
        {
            var books = await _bookService.GetBooksByAuthorAsync(authorId);
            return Ok(books);
        }

        [HttpGet("publisher/{publisherId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByPublisher(int publisherId)
        {
            var books = await _bookService.GetBooksByPublisherAsync(publisherId);
            return Ok(books);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByCategory(int categoryId)
        {
            var books = await _bookService.GetBooksByCategoryAsync(categoryId);
            return Ok(books);
        }

        [HttpGet("shelf/{shelfCode}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByShelf(string shelfCode)
        {
            var books = await _bookService.GetBooksByShelfAsync(shelfCode);
            return Ok(books);
        }

        [HttpGet("floor/{floorNumber}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByFloor(int floorNumber)
        {
            var books = await _bookService.GetBooksByFloorAsync(floorNumber);
            return Ok(books);
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetOverdueBooks()
        {
            var books = await _bookService.GetOverdueBooksAsync();
            return Ok(books);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("Search term is required");

            var books = await _bookService.SearchBooksAsync(q);
            return Ok(books);
        }
    }
} 