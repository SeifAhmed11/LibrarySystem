using LibraryAPI.Application.DTOs;

namespace LibraryAPI.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDto?> GetEmployeeDetailsByIdAsync(int id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByFloorAsync(int floorNumber);
        Task<EmployeeDto?> GetFloorManagerAsync(int floorNumber);
    }
} 