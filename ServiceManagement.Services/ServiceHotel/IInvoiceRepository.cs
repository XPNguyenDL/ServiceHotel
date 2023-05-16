
﻿using ServiceManagement.Core.DTO;
using ServiceManagement.Core.Entities;

public interface IInvoiceRepository
{
	Task<IList<Invoice>> GetInvoicesByRoomAsync(int roomId, CancellationToken cancellationToken = default);

	Task<Invoice> GetInvoiceDetailByIdAsync(int roomId, CancellationToken cancellationToken = default);

	Task<Invoice> CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken = default);
	Task<Invoice> AddServicesInvoiceAsync(int invoiceId, IList<ServicesInvoiceDto> servicesInvoices, CancellationToken cancellationToken = default);

	Task<bool> DeletedInvoiceAsync(int invoiceId, CancellationToken cancellationToken = default);

    Task<List<Invoice>> GetInvoicesByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);

    Task<List<Invoice>> GetInvoicesByServiceAsync(int serviceId, CancellationToken cancellationToken = default);

    Task<List<Invoice>> GetInvoicesByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

	// Revenue
	Task<double> RevenueByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);

    Task<double> RevenueByServiceAsync(int  serviceId, CancellationToken cancellationToken = default);

    Task<double> RevenueByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    
    Task<Invoice> UpdateServicesInvoiceAsync(int invoiceId, IList<ServicesInvoiceDto> servicesInvoices, CancellationToken cancellationToken = default);
}