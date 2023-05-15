namespace ServiceManagement.Core.DTO {
    public class ServiceDTO {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public bool Available { get; set; }

        public int CategoryId { get; set; }
    }
}
