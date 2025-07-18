using AutoMapper;
using LibraryAPI.Application.DTOs;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<BookBorrow> _bookBorrowRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository,
                          IGenericRepository<Employee> employeeRepository,
                          IGenericRepository<BookBorrow> bookBorrowRepository,
                          IMapper mapper)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _bookBorrowRepository = bookBorrowRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserBySSNAsync(string ssn)
        {
            var user = await _userRepository.GetByIdAsync(ssn);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var createdUser = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> UpdateUserAsync(string ssn, UpdateUserDto updateUserDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(ssn);
            if (existingUser == null)
                throw new ArgumentException("User not found");

            _mapper.Map(updateUserDto, existingUser);
            await _userRepository.UpdateAsync(existingUser);
            return _mapper.Map<UserDto>(existingUser);
        }

        public async Task DeleteUserAsync(string ssn)
        {
            var user = await _userRepository.GetByIdAsync(ssn);
            if (user == null)
                throw new ArgumentException("User not found");

            await _userRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByEmployeeAsync(int employeeId)
        {
            var users = await _userRepository.GetAllAsync();
            var employeeUsers = users.Where(u => u.RegisteredByEmployeeId == employeeId);
            return _mapper.Map<IEnumerable<UserDto>>(employeeUsers);
        }

        public async Task<IEnumerable<BookBorrowDto>> GetUserBorrowsAsync(string ssn)
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var userBorrows = borrows.Where(bb => bb.UserSSN == ssn);
            return _mapper.Map<IEnumerable<BookBorrowDto>>(userBorrows);
        }

        public async Task<IEnumerable<UserDto>> GetUsersWithOverdueBooksAsync()
        {
            var borrows = await _bookBorrowRepository.GetAllAsync();
            var overdueBorrows = borrows.Where(bb => bb.DueDate < DateTime.Now);
            var overdueUserSSNs = overdueBorrows.Select(bb => bb.UserSSN).Distinct();
            
            var users = await _userRepository.GetAllAsync();
            var overdueUsers = users.Where(u => overdueUserSSNs.Contains(u.SSN));
            return _mapper.Map<IEnumerable<UserDto>>(overdueUsers);
        }
    }
} 