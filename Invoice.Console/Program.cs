using ServiceManagement.Core.DTO;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;
using ServiceManagement.Data.Seeders;
using ServiceManagement.Services.ServiceHotel;
using System.Text;

var context = new ServiceDbContext();

IInvoiceRepository repository = new InvoiceRepository(context);
Console.OutputEncoding = Encoding.UTF8;

var seeder = new DataSeeder(context);
seeder.Initialize();

#region Task: Create invoice

//var invoiceEdit = new Invoice()
//{
//	RoomId = 1,
//	Note = "Test",

//};

//var invoice = await repository.CreateInvoiceAsync(invoiceEdit);

//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Create invoice");

//Console.WriteLine("Id: " + invoice.Id);
//Console.WriteLine("RoomId: " + invoice.RoomId);
//Console.WriteLine("PaymentDate: " + invoice.PaymentDate);
//Console.WriteLine("Note: " + invoice.Note);
//Console.WriteLine("".PadRight(80, '-'));

//var servicesInvoices = new List<ServicesInvoiceDto>()
//{
//	new()
//	{
//		ServiceId = 1,
//		Quantity = 2,
//	},
//	new()
//	{
//		ServiceId = 2,
//		Quantity = 2,
//	}
//};

//invoice = await repository.AddServicesInvoiceAsync(invoice.Id, servicesInvoices);


//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Add services invoice");

//Console.WriteLine("Id: " + invoice.Id);
//Console.WriteLine("RoomId: " + invoice.RoomId);
//Console.WriteLine("PaymentDate: " + invoice.PaymentDate);
//Console.WriteLine("Note: " + invoice.Note);
//foreach (var servicesInvoice in invoice.ServicesInvoices)
//{

//	Console.WriteLine("ServiceId: " + servicesInvoice.ServiceId);
//	Console.WriteLine("Price: " + servicesInvoice.Price);
//	Console.WriteLine("Quantity: " + servicesInvoice.Quantity);
//}
//Console.WriteLine("".PadRight(80, '-'));
#endregion

#region Task: Show invoices by room
//var invoices = await repository.GetInvoicesByRoomAsync(1);

//foreach (var invoice in invoices)
//{
//	Console.WriteLine("".PadRight(80, '-'));
//	Console.WriteLine("Invoice");

//	Console.WriteLine("Id: " + invoice.Id);
//	Console.WriteLine("RoomId: " + invoice.RoomId);
//	Console.WriteLine("PaymentDate: " + invoice.PaymentDate);
//	Console.WriteLine("Total: " + invoice.Total);
//	Console.WriteLine("Paid: {0} ", invoice.Paid ? "Paid" : "Unpaid");
//	Console.WriteLine("Note: " + invoice.Note);
//	Console.WriteLine("".PadRight(80, '_'));
//	foreach (var servicesInvoice in invoice.ServicesInvoices)
//	{
//		Console.WriteLine("ServiceId: " + servicesInvoice.ServiceId);
//		Console.WriteLine("Price: " + servicesInvoice.Price);
//		Console.WriteLine("Quantity: " + servicesInvoice.Quantity);
//	}

//	Console.WriteLine("".PadRight(80, '-'));
//}
#endregion

#region Task: Show invoice detail
//var invoice = await repository.GetInvoiceDetailByIdAsync(6);

//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Invoice detail");

//Console.WriteLine("Id: " + invoice.Id);
//Console.WriteLine("RoomId: " + invoice.RoomId);
//Console.WriteLine("PaymentDate: " + invoice.PaymentDate);
//Console.WriteLine("Total: " + invoice.Total);
//Console.WriteLine("Paid: {0} ", invoice.Paid ? "Paid" : "Unpaid");
//Console.WriteLine("Note: " + invoice.Note);
//Console.WriteLine("".PadRight(80, '_'));
//foreach (var servicesInvoice in invoice.ServicesInvoices)
//{
//	Console.WriteLine("ServiceId: " + servicesInvoice.ServiceId);
//	Console.WriteLine("Price: " + servicesInvoice.Price);
//	Console.WriteLine("Quantity: " + servicesInvoice.Quantity);
//}

//Console.WriteLine("".PadRight(80, '-'));
#endregion

#region Task: Delete invoice

//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Restore Services from recycle bin");

//if (await repository.DeletedInvoiceAsync(6))
//{
//	Console.WriteLine("Result: Restore success");
//}
//else
//{
//	Console.WriteLine("Result: Restore fail");
//}

#endregion


#region Task: Update service usaged in room
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: To modify the information regarding the room's service usage");

//int invoiceId = 1;

//var servicesInvoices = new List<ServicesInvoiceDto>()
//{
//    new()
//    {
//        ServiceId = 8,
//        Quantity = 2,
//    },
//    new()
//    {
//        ServiceId = 2,
//        Quantity = 5,
//    }
//};

//var invoice = await repository.UpdateServicesInvoiceAsync(invoiceId, servicesInvoices);

//if (invoice != null)
//{

//    Console.WriteLine("".PadRight(80, '-'));
//    Console.WriteLine("Update services invoice");

//    Console.WriteLine("Id: " + invoice.Id);
//    Console.WriteLine("RoomId: " + invoice.RoomId);
//    Console.WriteLine("PaymentDate: " + invoice.PaymentDate);
//    Console.WriteLine("Note: " + invoice.Note);
//    foreach (var servicesInvoice in invoice.ServicesInvoices)
//    {

//        Console.WriteLine("ServiceId: " + servicesInvoice.ServiceId);
//        Console.WriteLine("Price: " + servicesInvoice.Price);
//        Console.WriteLine("Quantity: " + servicesInvoice.Quantity);
//    }
//    Console.WriteLine("".PadRight(80, '-'));
//}
//else
//{
//    Console.WriteLine("Update failed");
//}
#endregion