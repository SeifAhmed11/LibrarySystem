using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorsController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorDto>>> GetFloors()
        {
            var floors = await _floorService.GetAllFloorsAsync();
            return Ok(floors);
        }

        [HttpGet("{floorNumber}")]
        public async Task<ActionResult<FloorDto>> GetFloor(int floorNumber)
        {
            var floor = await _floorService.GetFloorByNumberAsync(floorNumber);
            if (floor == null)
                return NotFound();

            return Ok(floor);
        }

        [HttpPost]
        public async Task<ActionResult<FloorDto>> CreateFloor(CreateFloorDto createFloorDto)
        {
            try
            {
                var floor = await _floorService.CreateFloorAsync(createFloorDto);
                return CreatedAtAction(nameof(GetFloor), new { floorNumber = floor.FloorNumber }, floor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{floorNumber}")]
        public async Task<IActionResult> UpdateFloor(int floorNumber, UpdateFloorDto updateFloorDto)
        {
            try
            {
                var floor = await _floorService.UpdateFloorAsync(floorNumber, updateFloorDto);
                return Ok(floor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{floorNumber}")]
        public async Task<IActionResult> DeleteFloor(int floorNumber)
        {
            try
            {
                await _floorService.DeleteFloorAsync(floorNumber);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{floorNumber}/manager")]
        public async Task<ActionResult<EmployeeDto>> GetFloorManager(int floorNumber)
        {
            var manager = await _floorService.GetFloorManagerAsync(floorNumber);
            if (manager == null)
                return NotFound();

            return Ok(manager);
        }

        [HttpGet("{floorNumber}/employees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetFloorEmployees(int floorNumber)
        {
            var employees = await _floorService.GetFloorEmployeesAsync(floorNumber);
            return Ok(employees);
        }

        [HttpGet("{floorNumber}/shelves")]
        public async Task<ActionResult<IEnumerable<ShelfDto>>> GetFloorShelves(int floorNumber)
        {
            var shelves = await _floorService.GetFloorShelvesAsync(floorNumber);
            return Ok(shelves);
        }
    }
} 