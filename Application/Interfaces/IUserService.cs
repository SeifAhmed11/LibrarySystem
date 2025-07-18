using LibraryAPI.Application.DTOs;

namespace LibraryAPI.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserBySSNAsync(string ssn);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> UpdateUserAsync(string ssn, UpdateUserDto updateUserDto);
        Task DeleteUserAsync(string ssn);
        Task<IEnumerable<UserDto>> GetUsersByEmployeeAsync(int employeeId);
        Task<IEnumerable<BookBorrowDto>> GetUserBorrowsAsync(string ssn);
        Task<IEnumerable<UserDto>> GetUsersWithOverdueBooksAsync();
    }
} 