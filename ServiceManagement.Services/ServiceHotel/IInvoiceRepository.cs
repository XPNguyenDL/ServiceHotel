using ServiceManagement.Core.Entities;

namespace ServiceManagement.Services.ServiceHotel;

public interface IInvoiceRepository
{
    Task<List<Invoice>> GetInvoicesByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);

    Task<List<Invoice>> GetInvoicesByServiceAsync(int serviceId, CancellationToken cancellationToken = default);

    Task<List<Invoice>> GetInvoicesByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    // Renevue
    Task<double> RenevueByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);

    Task<double> RenevueByServiceAsync(int  serviceId, CancellationToken cancellationToken = default);

    Task<double> RenevueByTimeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);


}