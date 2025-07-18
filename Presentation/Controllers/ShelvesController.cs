using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShelvesController : ControllerBase
    {
        private readonly IGenericRepository<Shelf> _shelfRepository;
        private readonly IMapper _mapper;

        public ShelvesController(IGenericRepository<Shelf> shelfRepository, IMapper mapper)
        {
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelfDto>>> GetShelves()
        {
            var shelves = await _shelfRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ShelfDto>>(shelves));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ShelfDto>> GetShelf(string code)
        {
            var shelf = await _shelfRepository.GetByIdAsync(code);
            if (shelf == null)
                return NotFound();

            return Ok(_mapper.Map<ShelfDto>(shelf));
        }

        [HttpPost]
        public async Task<ActionResult<ShelfDto>> CreateShelf(CreateShelfDto createShelfDto)
        {
            var shelf = _mapper.Map<Shelf>(createShelfDto);
            var createdShelf = await _shelfRepository.AddAsync(shelf);
            return CreatedAtAction(nameof(GetShelf), new { code = createdShelf.Code }, _mapper.Map<ShelfDto>(createdShelf));
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateShelf(string code, UpdateShelfDto updateShelfDto)
        {
            var existingShelf = await _shelfRepository.GetByIdAsync(code);
            if (existingShelf == null)
                return NotFound();

            _mapper.Map(updateShelfDto, existingShelf);
            await _shelfRepository.UpdateAsync(existingShelf);
            return Ok(_mapper.Map<ShelfDto>(existingShelf));
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteShelf(string code)
        {
            var shelf = await _shelfRepository.GetByIdAsync(code);
            if (shelf == null)
                return NotFound();

            await _shelfRepository.DeleteAsync(shelf);
            return NoContent();
        }

        [HttpGet("floor/{floorNumber}")]
        public async Task<ActionResult<IEnumerable<ShelfDto>>> GetShelvesByFloor(int floorNumber)
        {
            var shelves = await _shelfRepository.GetAllAsync();
            var floorShelves = shelves.Where(s => s.FloorNumber == floorNumber);
            return Ok(_mapper.Map<IEnumerable<ShelfDto>>(floorShelves));
        }
    }
} 