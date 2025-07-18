namespace LibraryAPI.Application.DTOs
{
    public class PublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }

    public class CreatePublisherDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdatePublisherDto
    {
        public string Name { get; set; } = string.Empty;
    }
} 