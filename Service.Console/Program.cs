using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.ServiceHotel;

var context = new ServiceDbContext();
IServiceRepository serviceRepository = new ServiceRepository(context);

#region Task: Delete permanently a Service by Id
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Delete permanently a Service by Id");
//Console.WriteLine("Result:");
//var isSuccess = await serviceRepository.DeleteServiceByIdAsync(9);

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

#region Task: Update Service information
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Update Service information");
//Console.WriteLine("Result:");
//var isSuccess = await serviceRepository.ToggleServiceAvailableStatusAsync(1);
//if (isSuccess)
//    Console.WriteLine("Toggled successfully.");
//else
//    Console.WriteLine("Toggled failed.");
//Console.WriteLine("----------------------------------------");
#endregion