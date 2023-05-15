using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.ServiceHotel;

var context = new ServiceDbContext();
IServiceRepository serviceRepository = new ServiceRepository(context);

#region Task: Delete permanently a Service by Id
Console.WriteLine("----------------------------------------");
var isSuccess = await serviceRepository.DeleteServiceByIdAsync(9);
Console.WriteLine("Task: Delete permanently a Service by Id");
Console.WriteLine("Result:");
if (isSuccess)
    Console.WriteLine("Service deleted.");
else
    Console.WriteLine("Service not found.");
Console.WriteLine("----------------------------------------");
#endregion