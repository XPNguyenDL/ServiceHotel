using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Mappings;

namespace ServiceManagement.Data.Contexts
{
    public class ServiceDbContext : DbContext
    {
	    public DbSet<Category> Categories { get; set; }

	    public DbSet<Service> Services { get; set; }

	    public DbSet<Feedback> Feedback { get; set; }

	    public DbSet<Price> Prices { get; set; }

	    public DbSet<PriceHistory> PriceHistories { get; set; }

	    public DbSet<Room> Rooms { get; set; }

	    public DbSet<Invoice> Invoices { get; set; }

	    public DbSet<ServicesInvoice> ServicesInvoices { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(local);Database=ServiceHotel;
                Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
		}
    }
}
