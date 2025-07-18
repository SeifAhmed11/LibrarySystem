using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeDetails(int id)
        {
            var employee = await _employeeService.GetEmployeeDetailsByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var employee = await _employeeService.CreateEmployeeAsync(createEmployeeDto);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmpId }, employee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
                return Ok(employee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("floor/{floorNumber}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByFloor(int floorNumber)
        {
            var employees = await _employeeService.GetEmployeesByFloorAsync(floorNumber);
            return Ok(employees);
        }

        [HttpGet("floor/{floorNumber}/manager")]
        public async Task<ActionResult<EmployeeDto>> GetFloorManager(int floorNumber)
        {
            var manager = await _employeeService.GetFloorManagerAsync(floorNumber);
            if (manager == null)
                return NotFound();

            return Ok(manager);
        }
    }
} 