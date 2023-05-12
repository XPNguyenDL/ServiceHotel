using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;

namespace ServiceManagement.Data.Seeders;

public class DataSeeder : IDataSeeder
{
	private readonly ServiceDbContext _dbContext;

	public DataSeeder(ServiceDbContext dbContext)
	{
		_dbContext = dbContext;
	}


	public void Initialize()
	{
		_dbContext.Database.EnsureCreated();

		if (_dbContext.Services.Any())
		{
			return;
		}

		var categories = Categories();
		var rooms = Rooms();
		var prices = Prices();
		var services = Services(categories);
		var priceHistories = PriceHistory(prices, services);
	}

	private IList<Category> Categories()
	{
		var categories = new List<Category>()
		{
			new()
			{
				Name = "Dịch vụ phòng",
				Description = "Mô tả"
			},
			new()
			{
				Name = "Dịch vụ ăn uống",
				Description = "Mô tả"
			},
			new()
			{
				Name = "Dịch vụ xe",
				Description = "Mô tả"
			},
			
		};

		_dbContext.Categories.AddRange(categories);
		_dbContext.SaveChanges();

		return categories;
	}

	private IList<Room> Rooms()
	{
		var rooms = new List<Room>()
		{
			new(),
			new(),
			new(),
			new(),
			new(),
			new(),
			new(),
			new(),
			new(),
		};

		_dbContext.Rooms.AddRange(rooms);
		_dbContext.SaveChanges();

		return rooms;
	}

	private IList<Price> Prices()
	{
		var prices = new List<Price>()
		{
			new()
			{
				ServicePrice = 200000,
				Discount = 0.2d,
			},
			new()
			{
				ServicePrice = 3000000,
				Discount = 0.2d
			},
			new()
			{
				ServicePrice = 400000,
			},
			new()
			{
				ServicePrice = 350000,
				Discount = 0.15d
			},
			new()
			{
				ServicePrice = 450000,
			},
			new()
			{
				ServicePrice = 350000,
			},
			new()
			{
				ServicePrice = 450000,
				Discount = 0.3d
			},
			new()
			{
				ServicePrice = 550000,
			},
			new()
			{
				ServicePrice = 400000,
				Discount = 0.4d
			},
			new()
			{
				ServicePrice = 750000,
			}
		};

		_dbContext.Prices.AddRange(prices);
		_dbContext.SaveChanges();

		return prices;
	}

	private IList<Service> Services(IList<Category> categories)
	{
		var services = new List<Service>()
		{
			new()
			{
				Name = "Dọn phòng",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[0].Id
			},
			new()
			{
				Name = "Ăn sáng",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[1].Id
			},
			new()
			{
				Name = "Dịch vụ giặt ủi",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[0].Id
			},
			new()
			{
				Name = "Cho thuê xe máy",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[2].Id
			},
			new()
			{
				Name = "Bãi đậu xe miễn phí",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[2].Id,
				
			},
			new()
			{
				Name = "Xe đón tại sân bay",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[2].Id
			},
			new()
			{
				Name = "Nước đóng chai miễn phí",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[0].Id
			},
			new()
			{
				Name = "Xe đưa đón",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[2].Id
			},
			new()
			{
				Name = "Dịch vụ taxi",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[2].Id
			},
			new()
			{
				Name = "Cho thuê xe đạp",
				ShortDescription = "Mô tả ngắn",
				Description = "Mô tả",
				CategoryId = categories[2].Id
			},
		};

		_dbContext.Services.AddRange(services);
		_dbContext.SaveChanges();

		return services;
	}

	private IList<PriceHistory> PriceHistory(IList<Price> prices, IList<Service> services)
	{
		var priceHistories = new List<PriceHistory>()
		{
			new()
			{
				ServiceId = services[0].Id,
				PriceId = prices[0].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[1].Id,
				PriceId = prices[1].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[2].Id,
				PriceId = prices[2].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				PriceId = prices[3].Id,
				ServiceId = services[3].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[4].Id,
				PriceId = prices[4].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[5].Id,
				PriceId = prices[5].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[6].Id,
				PriceId = prices[6].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[7].Id,
				PriceId = prices[7].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[8].Id,
				PriceId = prices[8].Id,
				ModifyTime = DateTime.Now,
			},
			new()
			{
				ServiceId = services[9].Id,
				PriceId = prices[9].Id,
				ModifyTime = DateTime.Now,
			},
		};

		_dbContext.PriceHistories.AddRange(priceHistories);
		_dbContext.SaveChanges();

		return priceHistories;
	}
}