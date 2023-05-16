using ServiceManagement.Core.DTO;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Services.ServiceHotel;

public interface IInvoiceRepository
{
	Task<IList<Invoice>> GetInvoicesByRoomAsync(int roomId, CancellationToken cancellationToken = default);

	Task<Invoice> GetInvoiceDetailByIdAsync(int roomId, CancellationToken cancellationToken = default);

	Task<Invoice> CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken = default);
	Task<Invoice> AddServicesInvoiceAsync(int invoiceId, IList<ServicesInvoiceDto> servicesInvoices, CancellationToken cancellationToken = default);
    Task<Invoice> UpdateServicesInvoiceAsync(int invoiceId, IList<ServicesInvoiceDto> servicesInvoices, CancellationToken cancellationToken = default);
    Task<bool> DeletedInvoiceAsync(int invoiceId, CancellationToken cancellationToken = default);
}