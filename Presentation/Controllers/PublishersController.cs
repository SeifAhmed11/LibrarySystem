using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly IGenericRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;

        public PublishersController(IGenericRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetPublishers()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherDto>> GetPublisher(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                return NotFound();

            return Ok(_mapper.Map<PublisherDto>(publisher));
        }

        [HttpPost]
        public async Task<ActionResult<PublisherDto>> CreatePublisher(CreatePublisherDto createPublisherDto)
        {
            var publisher = _mapper.Map<Publisher>(createPublisherDto);
            var createdPublisher = await _publisherRepository.AddAsync(publisher);
            return CreatedAtAction(nameof(GetPublisher), new { id = createdPublisher.Id }, _mapper.Map<PublisherDto>(createdPublisher));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, UpdatePublisherDto updatePublisherDto)
        {
            var existingPublisher = await _publisherRepository.GetByIdAsync(id);
            if (existingPublisher == null)
                return NotFound();

            _mapper.Map(updatePublisherDto, existingPublisher);
            await _publisherRepository.UpdateAsync(existingPublisher);
            return Ok(_mapper.Map<PublisherDto>(existingPublisher));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                return NotFound();

            await _publisherRepository.DeleteAsync(publisher);
            return NoContent();
        }
    }
} 