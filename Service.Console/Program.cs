using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;
using ServiceManagement.Data.Seeders;
using ServiceManagement.Services.ServiceHotel;
using System.Text.RegularExpressions;

var context = new ServiceDbContext();

IServiceRepository serviceRepository = new ServiceRepository(context);


var seeder = new DataSeeder(context);
seeder.Initialize();

// U2.2 Create Service
#region 
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Create Service");

//var createService = new Service()
//{
//    Id = 10,
//    Name = "Dich vu test",
//    ShortDescription = "Dich vu test  ShortDescription",
//    Description = "Dich vu test  Description",
//    CategoryId = 1
//};
//var createdService = await serviceRepository.CreateServiceAsync(createService);
//Console.WriteLine("Id: " + createdService.Id);
//Console.WriteLine("Name: " + createdService.Name);
//Console.WriteLine("Short Description: " + createdService.ShortDescription);
//Console.WriteLine("Description: " + createdService.Description);
//Console.WriteLine("Isdeleted: " + createdService.IsDeleted);
//Console.WriteLine("Available: " + createdService.Available);
//Console.WriteLine("CategoryId: " + createdService.CategoryId);
//Console.WriteLine("".PadRight(80, '-'));
#endregion

// Change Service delete status
#region
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Change Service delete status");
//var deleteStatus = await serviceRepository.ChangeServiceDeleteStatusAsync(2);
//if (deleteStatus)
//    Console.WriteLine("Change successfully.");
//else
//    Console.WriteLine("Change failed.");
//Console.WriteLine("".PadRight(80, '-'));
#endregion

// Get Services
#region
//var services = await serviceRepository.GetServicesAsync();

//Console.WriteLine("{0,-5}{1,-10}{2,40}{3,55}",
//    "ID", "Name", "Short Description" , "Description");

//foreach (var item in services)
//{
//    Console.WriteLine("{0,-5}{1,-10}{2,40}{3,55}",
//        item.Id, item.Name, item.ShortDescription, item.Description);
//}
#endregion
