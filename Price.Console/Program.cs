using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.ServiceHotel;

var context = new ServiceDbContext();
IPriceRepository priceRepository = new PriceRepository(context);

#region Task: Update Price
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Task: Update Price");
//Console.WriteLine("Result:");
//var price = await priceRepository.GetPriceByServiceIdAsync(3);
//Console.WriteLine("Old price id: " + price.Id);
//Console.WriteLine("Old price service price: " + price.ServicePrice);
//Console.WriteLine("Old price discount: " + price.Discount);
//price.ServicePrice = 500000;
//price.Discount = 0.5;
//var updatedPrice = await priceRepository.UpdatePriceAsync(price, "nothing");
//Console.WriteLine("New price id: " + updatedPrice.Id);
//Console.WriteLine("New price service price: " + updatedPrice.ServicePrice);
//Console.WriteLine("New price discount: " + updatedPrice.Discount);
//Console.WriteLine("----------------------------------------");
#endregion