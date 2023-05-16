namespace ServiceManagement.Core.DTO
{
    public class CategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public bool IsDeleted { get; set; }

        public int ServicesCount { get; set; } 
    }
}
