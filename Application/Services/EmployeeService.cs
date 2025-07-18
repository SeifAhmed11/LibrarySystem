using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Floor> _floorRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, 
                             IGenericRepository<Floor> floorRepository,
                             IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto?> GetEmployeeDetailsByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return null;

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDto);
            var createdEmployee = await _employeeRepository.AddAsync(employee);
            return _mapper.Map<EmployeeDto>(createdEmployee);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null)
                throw new ArgumentException("Employee not found");

            _mapper.Map(updateEmployeeDto, existingEmployee);
            await _employeeRepository.UpdateAsync(existingEmployee);
            return _mapper.Map<EmployeeDto>(existingEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                throw new ArgumentException("Employee not found");

            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByFloorAsync(int floorNumber)
        {
            // This would need a more specific repository method or query
            var employees = await _employeeRepository.GetAllAsync();
            var floorEmployees = employees.Where(e => e.FloorId == floorNumber);
            return _mapper.Map<IEnumerable<EmployeeDto>>(floorEmployees);
        }

        public async Task<EmployeeDto?> GetFloorManagerAsync(int floorNumber)
        {
            // This would need a more specific repository method or query
            var employees = await _employeeRepository.GetAllAsync();
            var manager = employees.FirstOrDefault(e => e.ManagedFloorId == floorNumber);
            return _mapper.Map<EmployeeDto>(manager);
        }
    }
} 