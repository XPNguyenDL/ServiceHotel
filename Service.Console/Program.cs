using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.ServiceHotel;

var context = new ServiceDbContext();
IServiceRepository serviceRepository = new ServiceRepository(context);
IPriceRepository priceRepository = new PriceRepository(context);

#region Task: Delete permanently a Service by Id
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Delete permanently a Service by Id");
//Console.WriteLine("Result:");
//var price = await priceRepository.GetPriceByServiceIdAsync(4);
//if (price != null) {
//    await priceRepository.DeletePriceByIdAsync(price.Id);
//}

//var isSuccess = await serviceRepository.DeleteServiceByIdAsync(4);

//if (isSuccess)
//    Console.WriteLine("Service deleted.");
//else
//    Console.WriteLine("Service not found.");

//Console.WriteLine("----------------------------------------");
#endregion

#region Task: Update Service information
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Update Service information");
//Console.WriteLine("Result:");
//var newService = new Service() {
//    Id = 9,
//    Name = "Dịch vụ taxi",
//    ShortDescription = "Dịch vụ đặt xe taxi hộ",
//    Description = "Khi khách hàng sử dụng dịch vụ này, khách sạn sẽ đặt hộ taxi theo yêu cầu của khách hàng và không thu thêm bất kì chi phí dịch vụ nào.",
//    IsDeleted = false,
//    Available = true,
//    CategoryId = 3
//};
//var updatedService = await serviceRepository.UpdateServiceInfomationAsync(newService);
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
//    Console.WriteLine("Toggled successfully.");
//else
//    Console.WriteLine("Toggled failed.");
//Console.WriteLine("----------------------------------------");
#endregion

#region Task: Find Services by query
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Find Services by query");
//Console.WriteLine("Result:");
//var query = new ServiceQuery() {
//    IsDeleted = true,
//    Available = true,
//};
//var pagingParams = new PagingParams() {
//    PageNumber = 1,
//    PageSize = 10,
//};
//var services = await serviceRepository.GetPagedServicesByQueryAsync(query, pagingParams);
//Console.WriteLine();
//foreach (var service in services) {
//    var price = await priceRepository.GetPriceByServiceIdAsync(service.Id);
//    Console.WriteLine("Service name: " + service.Name);
//    Console.WriteLine("Service short description: " + service.ShortDescription);
//    Console.WriteLine("Service description: " + service.Description);
//    Console.WriteLine("Service price: " + price.ServicePrice);
//    Console.WriteLine("Service deleted status: " + service.IsDeleted);
//    Console.WriteLine("Service available status: " + service.Available);
//    Console.WriteLine("Service category id: " + service.CategoryId);
//    Console.WriteLine();
//}

//Console.WriteLine("----------------------------------------");
#endregion