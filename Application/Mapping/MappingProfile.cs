using AutoMapper;
using LibraryAPI.Core.Entities;
using LibraryAPI.Application.DTOs;

namespace LibraryAPI.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Employee mappings
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();

            // Floor mappings
            CreateMap<Floor, FloorDto>();
            CreateMap<CreateFloorDto, Floor>();
            CreateMap<UpdateFloorDto, Floor>();

            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CatName))
                .ForMember(dest => dest.FloorNumber, opt => opt.MapFrom(src => src.Shelf.Floor.FloorNumber.ToString()))
                .ForMember(dest => dest.AuthorNames, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author.Name)))
                .ForMember(dest => dest.BorrowCount, opt => opt.MapFrom(src => src.BookBorrows.Count));

            CreateMap<Book, BookDetailDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            // Author mappings
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();

            // Publisher mappings
            CreateMap<Publisher, PublisherDto>();
            CreateMap<CreatePublisherDto, Publisher>();
            CreateMap<UpdatePublisherDto, Publisher>();

            // Category mappings
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            // Shelf mappings
            CreateMap<Shelf, ShelfDto>();
            CreateMap<CreateShelfDto, Shelf>();
            CreateMap<UpdateShelfDto, Shelf>();

            // BookBorrow mappings
            CreateMap<BookBorrow, BookBorrowDto>();
            CreateMap<CreateBookBorrowDto, BookBorrow>();
            CreateMap<UpdateBookBorrowDto, BookBorrow>();
        }
    }
} 