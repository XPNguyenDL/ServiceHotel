using ServiceManagement.Data.Contexts;
using ServiceManagement.Data.Seeders;

var context = new ServiceDbContext();
var seeder = new DataSeeder(context);
seeder.Initialize();