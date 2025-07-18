using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Core.Entities;
using LibraryAPI.Core.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IGenericRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            var createdAuthor = await _authorRepository.AddAsync(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, _mapper.Map<AuthorDto>(createdAuthor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto updateAuthorDto)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(id);
            if (existingAuthor == null)
                return NotFound();

            _mapper.Map(updateAuthorDto, existingAuthor);
            await _authorRepository.UpdateAsync(existingAuthor);
            return Ok(_mapper.Map<AuthorDto>(existingAuthor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            await _authorRepository.DeleteAsync(author);
            return NoContent();
        }
    }
} 