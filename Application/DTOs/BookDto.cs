namespace LibraryAPI.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ShelfCode { get; set; } = string.Empty;
        public string FloorNumber { get; set; } = string.Empty;
        public List<string> AuthorNames { get; set; } = new List<string>();
        public int BorrowCount { get; set; }
    }

    public class BookDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public PublisherDto Publisher { get; set; } = new PublisherDto();
        public CategoryDto Category { get; set; } = new CategoryDto();
        public ShelfDto Shelf { get; set; } = new ShelfDto();
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public List<BookBorrowDto> BookBorrows { get; set; } = new List<BookBorrowDto>();
    }

    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public string ShelfCode { get; set; } = string.Empty;
        public List<int> AuthorIds { get; set; } = new List<int>();
    }

    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public string ShelfCode { get; set; } = string.Empty;
        public List<int> AuthorIds { get; set; } = new List<int>();
    }
} 