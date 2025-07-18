namespace LibraryAPI.Application.DTOs
{
    public class ShelfDto
    {
        public string Code { get; set; } = string.Empty;
        public FloorDto Floor { get; set; } = new FloorDto();
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }

    public class CreateShelfDto
    {
        public string Code { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
    }

    public class UpdateShelfDto
    {
        public string Code { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
    }
} 