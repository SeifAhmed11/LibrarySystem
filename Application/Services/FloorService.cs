using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Application.Services
{
    public class FloorService : IFloorService
    {
        private readonly IGenericRepository<Floor> _floorRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Shelf> _shelfRepository;
        private readonly IMapper _mapper;

        public FloorService(IGenericRepository<Floor> floorRepository,
                           IGenericRepository<Employee> employeeRepository,
                           IGenericRepository<Shelf> shelfRepository,
                           IMapper mapper)
        {
            _floorRepository = floorRepository;
            _employeeRepository = employeeRepository;
            _shelfRepository = shelfRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FloorDto>> GetAllFloorsAsync()
        {
            var floors = await _floorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FloorDto>>(floors);
        }

        public async Task<FloorDto?> GetFloorByNumberAsync(int floorNumber)
        {
            var floor = await _floorRepository.GetByIdAsync(floorNumber);
            return _mapper.Map<FloorDto>(floor);
        }

        public async Task<FloorDto> CreateFloorAsync(CreateFloorDto createFloorDto)
        {
            var floor = _mapper.Map<Floor>(createFloorDto);
            var createdFloor = await _floorRepository.AddAsync(floor);
            return _mapper.Map<FloorDto>(createdFloor);
        }

        public async Task<FloorDto> UpdateFloorAsync(int floorNumber, UpdateFloorDto updateFloorDto)
        {
            var existingFloor = await _floorRepository.GetByIdAsync(floorNumber);
            if (existingFloor == null)
                throw new ArgumentException("Floor not found");

            _mapper.Map(updateFloorDto, existingFloor);
            await _floorRepository.UpdateAsync(existingFloor);
            return _mapper.Map<FloorDto>(existingFloor);
        }

        public async Task DeleteFloorAsync(int floorNumber)
        {
            var floor = await _floorRepository.GetByIdAsync(floorNumber);
            if (floor == null)
                throw new ArgumentException("Floor not found");

            await _floorRepository.DeleteAsync(floor);
        }

        public async Task<EmployeeDto?> GetFloorManagerAsync(int floorNumber)
        {
            var employees = await _employeeRepository.GetAllAsync();
            var manager = employees.FirstOrDefault(e => e.ManagedFloorId == floorNumber);
            return _mapper.Map<EmployeeDto>(manager);
        }

        public async Task<IEnumerable<EmployeeDto>> GetFloorEmployeesAsync(int floorNumber)
        {
            var employees = await _employeeRepository.GetAllAsync();
            var floorEmployees = employees.Where(e => e.FloorId == floorNumber);
            return _mapper.Map<IEnumerable<EmployeeDto>>(floorEmployees);
        }

        public async Task<IEnumerable<ShelfDto>> GetFloorShelvesAsync(int floorNumber)
        {
            var shelves = await _shelfRepository.GetAllAsync();
            var floorShelves = shelves.Where(s => s.FloorNumber == floorNumber);
            return _mapper.Map<IEnumerable<ShelfDto>>(floorShelves);
        }
    }
} 