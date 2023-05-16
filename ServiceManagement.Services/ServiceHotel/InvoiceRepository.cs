using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Contracts;
using ServiceManagement.Core.Entities;
using ServiceManagement.Core.Queries;
using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.Extensions;

namespace ServiceManagement.Services.ServiceHotel;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ServiceDbContext _context;

    public InvoiceRepository(ServiceDbContext context)
    {
        _context = context;
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

    // Renevue

    public async Task<double> RenevueByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        var invoices = await GetInvoicesByCategoryAsync(categoryId, cancellationToken);

        double totalRevenue = 0;

        foreach (var invoice in invoices)
        {
            totalRevenue += invoice.Total;
        }

        return totalRevenue;
    }

    public async Task<double> RenevueByServiceAsync(int serviceId, CancellationToken cancellationToken = default)
    {
        var invoices = await GetInvoicesByServiceAsync(serviceId, cancellationToken);

        double totalRevenue = 0;

        foreach (var invoice in invoices)
        {
            totalRevenue += invoice.Total;
        }

        return totalRevenue;
    }

    public async Task<double> RenevueByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
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