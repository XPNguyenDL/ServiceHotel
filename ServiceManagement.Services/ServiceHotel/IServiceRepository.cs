using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Services.ServiceHotel;

public interface IServiceRepository
{

    Task<IList<Service>> GetServicesAsync(CancellationToken cancellationToken = default);

    Task<bool> ChangeServiceDeleteStatusAsync(int id, CancellationToken cancellationToken = default);

    Task<Service> CreateServiceAsync(Service service, CancellationToken cancellationToken = default);
}