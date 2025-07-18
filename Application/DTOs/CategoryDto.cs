namespace LibraryAPI.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CatName { get; set; } = string.Empty;
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }

    public class CreateCategoryDto
    {
        public string CatName { get; set; } = string.Empty;
    }

    public class UpdateCategoryDto
    {
        public string CatName { get; set; } = string.Empty;
    }
} 