using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.DTO;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;

namespace ServiceManagement.Services.ServiceHotel;

public class InvoiceRepository : IInvoiceRepository
{
	private readonly ServiceDbContext _context;
	public InvoiceRepository(ServiceDbContext context)
	{
		_context = context;
	}

	public async Task<IList<Invoice>> GetInvoicesByRoomAsync(int roomId, CancellationToken cancellationToken = default)
	{
		return await _context.Set<Invoice>()
			.Include(s => s.Room)
			.Include(s => s.ServicesInvoices)
			.Where(s => s.RoomId == roomId).ToListAsync(cancellationToken);
	}

	public async Task<Invoice> GetInvoiceDetailByIdAsync(int invoiceId, CancellationToken cancellationToken = default)
	{
		var invoice = await _context.Set<Invoice>()
			.Include(s => s.Room)
			.Include(s => s.ServicesInvoices)
			.FirstOrDefaultAsync(s => s.Id == invoiceId, cancellationToken);

		foreach (var servicesInvoice in invoice.ServicesInvoices)
		{
			invoice.Total += servicesInvoice.Price * servicesInvoice.Quantity;
		}

		return invoice;
	}

	public async Task<Invoice> CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken = default)
	{
		invoice.Paid = false;
		invoice.PaymentDate = DateTime.Now;
		
		_context.Invoices.Add(invoice);

		await _context.SaveChangesAsync(cancellationToken);
		return invoice;
	}

	public async Task<Invoice> AddServicesInvoiceAsync(int invoiceId, IList<ServicesInvoiceDto> servicesInvoices,
		CancellationToken cancellationToken = default)
	{
		var invoice = await _context.Set<Invoice>()
			.Include(s => s.Room)
			.Include(s => s.ServicesInvoices)
			.FirstOrDefaultAsync(s => s.Id == invoiceId, cancellationToken);

		foreach (var item in servicesInvoices)
		{

			var service = await _context.Set<Service>()
				.FirstOrDefaultAsync(s => s.Id == item.ServiceId, cancellationToken);

			var price = await _context.PriceHistories
				.Include(s => s.Price)
				.FirstOrDefaultAsync(s => s.ServiceId == service.Id, cancellationToken);

			var detail = new ServicesInvoice()
			{
				ServiceId = service.Id,
				Price = price.Price.ServicePrice,
				Quantity = item.Quantity,
				InvoiceId = invoiceId
			};

			invoice.Total += detail.Quantity * detail.Price;
			invoice.ServicesInvoices.Add(detail);
		}

		_context.Entry(invoice).State = EntityState.Modified;
		await _context.SaveChangesAsync(cancellationToken);

		return invoice;
	}

    public async Task<Invoice> UpdateServicesInvoiceAsync(int invoiceId, IList<ServicesInvoiceDto> servicesInvoices, CancellationToken cancellationToken = default)
    {

        var invoice = await _context.Set<Invoice>()
        .Include(s => s.Room)
        .Include(s => s.ServicesInvoices)
        .FirstOrDefaultAsync(s => s.Id == invoiceId, cancellationToken);

		if (invoice == null) return null;

        invoice.ServicesInvoices.Clear();
        return await AddServicesInvoiceAsync(invoiceId, servicesInvoices, cancellationToken);
    }

    public async Task<bool> DeletedInvoiceAsync(int invoiceId, CancellationToken cancellationToken = default)
	{

		return await _context.Invoices
			.Where(s => s.Id == invoiceId)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}

    public async Task<List<Invoice>> GetInvoicesByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var invoices = await (from invoice in _context.Invoices
                              join servicesInvoice in _context.ServicesInvoices
                                on invoice.Id equals servicesInvoice.InvoiceId
                              join service in _context.Services
                                on servicesInvoice.ServiceId equals service.Id
                              where service.CategoryId == categoryId
                              select invoice).ToListAsync(cancellationToken);

        return invoices;
    }

    public async Task<List<Invoice>> GetInvoicesByServiceAsync(int serviceId, CancellationToken cancellationToken = default) { 
        return await _context.Set<Invoice>()
            .Include(s => s.ServicesInvoices)
            .Where(i => i.ServicesInvoices.Any(si => si.ServiceId == serviceId && si.InvoiceId == i.Id))
            .ToListAsync(cancellationToken);    
    }

    public async Task<List<Invoice>> GetInvoicesByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        var invoices = await _context.Set<Invoice>()
           .Where(i => i.PaymentDate >= startDate && i.PaymentDate <= endDate)
           .ToListAsync(cancellationToken);

        return invoices;
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Invoice>()
            .FirstOrDefaultAsync(i => i.Id.Equals(invoiceId), cancellationToken);
    }

    // Revenue

    public async Task<double> RevenueByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var invoices = await GetInvoicesByCategoryAsync(categoryId, cancellationToken);

        double totalRevenue = 0;

        foreach (var invoice in invoices)
        {
            totalRevenue += invoice.Total;
        }

        return totalRevenue;
    }

    public async Task<double> RevenueByServiceAsync(int serviceId, CancellationToken cancellationToken = default)
    {
        var invoices = await GetInvoicesByServiceAsync(serviceId, cancellationToken);

        double totalRevenue = 0;

        foreach (var invoice in invoices)
        {
            totalRevenue += invoice.Total;
        }

        return totalRevenue;
    }

    public async Task<double> RevenueByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        var invoices = await GetInvoicesByTimeAsync(startDate, endDate, cancellationToken);

        if (invoices.Count == 0)
        {
            Console.WriteLine("There are no invoices within the specified time range.");
            return 0;
        }

        double totalRevenue = invoices.Sum(i => i.Total);

        return totalRevenue;
    }
}