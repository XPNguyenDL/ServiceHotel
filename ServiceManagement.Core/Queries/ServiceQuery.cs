namespace ServiceManagement.Core.Queries {
    public class ServiceQuery : IServiceQuery {
        public string Keyword { get; set; } = "";

        public bool IsDeleted { get; set; }

        public bool Available { get; set; }

        public int CategoryId { get; set; }
    }
}
