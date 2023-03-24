using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Contexts
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Room> Room { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

		public DbSet<Price> Prices { get; set; }

		public DbSet<PriceHistory> PriceHistories { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Car> Cars { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-FQ22EB1;Database=ServiceHotel;
                Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Room>()
				.HasMany(s => s.Services)
				.WithMany(s => s.Rooms)
				.UsingEntity(p => p.ToTable("ServiceRoom"));

			
		}
    }
}
