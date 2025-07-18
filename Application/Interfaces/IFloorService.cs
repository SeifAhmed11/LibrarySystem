using LibraryAPI.Application.DTOs;

namespace LibraryAPI.Application.Interfaces
{
    public interface IFloorService
    {
        Task<IEnumerable<FloorDto>> GetAllFloorsAsync();
        Task<FloorDto?> GetFloorByNumberAsync(int floorNumber);
        Task<FloorDto> CreateFloorAsync(CreateFloorDto createFloorDto);
        Task<FloorDto> UpdateFloorAsync(int floorNumber, UpdateFloorDto updateFloorDto);
        Task DeleteFloorAsync(int floorNumber);
        Task<EmployeeDto?> GetFloorManagerAsync(int floorNumber);
        Task<IEnumerable<EmployeeDto>> GetFloorEmployeesAsync(int floorNumber);
        Task<IEnumerable<ShelfDto>> GetFloorShelvesAsync(int floorNumber);
    }
} 