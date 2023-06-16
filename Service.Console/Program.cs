using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.ServiceHotel;
using System.Text;
using ServiceManagement.Core.Collections;
using ServiceManagement.Core.Entities;
using ServiceManagement.Core.Queries;

var context = new ServiceDbContext();
IServiceRepository serviceRepository = new ServiceRepository(context);
IPriceRepository priceRepository = new PriceRepository(context);
Console.OutputEncoding = Encoding.UTF8;

#region U2 .2 Create Service
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Create Service");

//var createService = new Service()
//{
//    Name = "Dich vu test",
//    ShortDescription = "Dich vu test  ShortDescription",
//    Description = "Dich vu test  Description",
//    CategoryId = 1
//};
//var createdService = await serviceRepository.CreateServiceAsync(createService);
//var price = new Price()
//{
//    ServicePrice = 200000,
//    Discount = 0.2,
//};
//var createdPrice = await priceRepository.AddPriceAsync(price);
//var priceHistory = new PriceHistory()
//{
//    ModifyTime = DateTime.Now,
//    PriceId = createdPrice.Id,
//    ServiceId = createdService.Id,
//};
//var createdPriceHistory = await priceRepository.AddPriceHistoryAsync(priceHistory);
//Console.WriteLine("Id: " + createdService.Id);
//Console.WriteLine("Name: " + createdService.Name);
//Console.WriteLine("Short Description: " + createdService.ShortDescription);
//Console.WriteLine("Description: " + createdService.Description);
//Console.WriteLine("Price: " + createdPrice.ServicePrice);
//Console.WriteLine("Discount: " + createdPrice.Discount * 100 + "%");
//Console.WriteLine("Isdeleted: " + createdService.IsDeleted);
//Console.WriteLine("Available: " + createdService.Available);
//Console.WriteLine("CategoryId: " + createdService.CategoryId);
//Console.WriteLine("".PadRight(80, '-'));
#endregion

#region Change Service delete status
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Change Service delete status");
//var deleteStatus = await serviceRepository.ChangeServiceDeleteStatusAsync(2);
//if (deleteStatus)
//	Console.WriteLine("Change successfully.");
//else
//	Console.WriteLine("Change failed.");
//Console.WriteLine("".PadRight(80, '-'));
#endregion

#region
//var services = await serviceRepository.GetServicesAsync();

//Console.WriteLine("{0,-5}{1,-10}{2,40}{3,55}",
//    "ID", "Name", "Short Description", "Description");

//foreach (var item in services)
//{
//    Console.WriteLine("{0,-5}{1,-10}{2,40}{3,55}",
//        item.Id, item.Name, item.ShortDescription, item.Description);
//}
#endregion

#region Task: Delete permanently a Service by Id
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Delete permanently a Service by Id");
//Console.WriteLine("Result:");
//var price = await priceRepository.GetPriceByServiceIdAsync(4);
//if (price != null)
//{
//	await priceRepository.DeletePriceByIdAsync(price.Id);
//}

//var isSuccess = await serviceRepository.DeleteServiceByIdAsync(4);

//if (isSuccess)
//	Console.WriteLine("Service deleted.");
//else
//	Console.WriteLine("Service not found.");

//Console.WriteLine("----------------------------------------");
#endregion

#region Task: Update Service information
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Update Service information");
//Console.WriteLine("Result:");
//var service = await serviceRepository.GetServiceByIdAsync(9);

//service.Name = "Dịch vụ Taxi (update)";
//service.ShortDescription = "Dịch vụ đặt xe taxi hộ";
//service.Description = "Dịch vụ đặt xe taxi.";
//service.IsDeleted = false;
//service.Available = true;
//service.CategoryId = 3;
//var updatedService = await serviceRepository.UpdateServiceInfomationAsync(service);
//Console.WriteLine("Service id: " + updatedService.Id);
//Console.WriteLine("Service name: " + updatedService.Name);
//Console.WriteLine("Service short description: " + updatedService.ShortDescription);
//Console.WriteLine("Service description: " + updatedService.Description);
//Console.WriteLine("Service is deleted: " + updatedService.IsDeleted);
//Console.WriteLine("Service available: " + updatedService.Available);
//Console.WriteLine("Service category id: " + updatedService.CategoryId);

//Console.WriteLine("----------------------------------------");
#endregion

#region Task: Toggle Service available status
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Toggle Service available status");
//Console.WriteLine("Result:");
//var isSuccess = await serviceRepository.ToggleServiceAvailableStatusAsync(1);
//if (isSuccess)
//	Console.WriteLine("Toggled successfully.");
//else
//	Console.WriteLine("Toggled failed.");
//Console.WriteLine("----------------------------------------");
#endregion

#region Task: Find Services by query
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Find Services by query");
//Console.WriteLine("Result:");
//var query = new ServiceQuery()
//{
//	IsDeleted = true,
//	Available = true,
//};
//var pagingParams = new PagingParams()
//{
//	PageNumber = 1,
//	PageSize = 10,
//};
//var services = await serviceRepository.GetPagedServicesByQueryAsync(query, pagingParams);
//Console.WriteLine();
//foreach (var service in services)
//{
//	var price = await priceRepository.GetPriceByServiceIdAsync(service.Id);
//	Console.WriteLine("Service name: " + service.Name);
//	Console.WriteLine("Service short description: " + service.ShortDescription);
//	Console.WriteLine("Service description: " + service.Description);
//	Console.WriteLine("Service price: " + price.ServicePrice);
//	Console.WriteLine("Service deleted status: " + service.IsDeleted);
//	Console.WriteLine("Service available status: " + service.Available);
//	Console.WriteLine("Service category id: " + service.CategoryId);
//	Console.WriteLine();
//}

//Console.WriteLine("----------------------------------------");
#endregion

#region Task: Restore Services from recycle bin
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Restore Services from recycle bin");

//if (await serviceRepository.RestoreServicesAsync(1))
//{
//	Console.WriteLine("Result: Restore success");
//}
//else
//{
//	Console.WriteLine("Result: Restore fail");
//}
#endregion
