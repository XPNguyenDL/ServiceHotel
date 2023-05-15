using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
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

	public async Task<bool> DeletedInvoiceAsync(int invoiceId, CancellationToken cancellationToken = default)
	{

		return await _context.Invoices
			.Where(s => s.Id == invoiceId)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}
}