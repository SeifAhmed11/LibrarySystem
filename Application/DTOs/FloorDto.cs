namespace LibraryAPI.Application.DTOs
{
    public class FloorDto
    {
        public int FloorNumber { get; set; }
        public int NumberOfBlocks { get; set; }
        public EmployeeDto? Manager { get; set; }
        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public List<ShelfDto> Shelves { get; set; } = new List<ShelfDto>();
    }

    public class CreateFloorDto
    {
        public int FloorNumber { get; set; }
        public int NumberOfBlocks { get; set; }
    }

    public class UpdateFloorDto
    {
        public int NumberOfBlocks { get; set; }
    }
} 