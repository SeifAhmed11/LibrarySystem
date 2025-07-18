using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;

namespace LibraryAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{ssn}")]
        public async Task<ActionResult<UserDto>> GetUser(string ssn)
        {
            var user = await _userService.GetUserBySSNAsync(ssn);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            try
            {
                var user = await _userService.CreateUserAsync(createUserDto);
                return CreatedAtAction(nameof(GetUser), new { ssn = user.SSN }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{ssn}")]
        public async Task<IActionResult> UpdateUser(string ssn, UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _userService.UpdateUserAsync(ssn, updateUserDto);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ssn}")]
        public async Task<IActionResult> DeleteUser(string ssn)
        {
            try
            {
                await _userService.DeleteUserAsync(ssn);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByEmployee(int employeeId)
        {
            var users = await _userService.GetUsersByEmployeeAsync(employeeId);
            return Ok(users);
        }

        [HttpGet("{ssn}/borrows")]
        public async Task<ActionResult<IEnumerable<BookBorrowDto>>> GetUserBorrows(string ssn)
        {
            var borrows = await _userService.GetUserBorrowsAsync(ssn);
            return Ok(borrows);
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersWithOverdueBooks()
        {
            var users = await _userService.GetUsersWithOverdueBooksAsync();
            return Ok(users);
        }
    }
} 