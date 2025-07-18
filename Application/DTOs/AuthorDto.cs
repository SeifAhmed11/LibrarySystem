namespace LibraryAPI.Application.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }

    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
    }
} 