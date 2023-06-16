using ServiceManagement.Core.Contracts;
using ServiceManagement.Core.Entities;
using ServiceManagement.Core.Queries;

namespace ServiceManagement.Services.ServiceHotel;

public interface IServiceRepository {
    /// <summary>
    /// Delete permanently a Service by Id
    /// </summary>
    /// <param name="id">Service's Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Deleted status</returns>
    Task<bool> DeleteServiceByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update Service infomation
    /// </summary>
    /// <param name="service">New Service infomation</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Updated Service</returns>
    Task<Service> UpdateServiceInfomationAsync(Service service, CancellationToken cancellationToken = default);

    /// <summary>
    /// Toggle Service available status
    /// </summary>
    /// <param name="id">Service's Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Toggle status</returns>
    Task<bool> ToggleServiceAvailableStatusAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Filter Services by query
    /// </summary>
    /// <param name="query">Service query</param>
    /// <returns>Service Queryable</returns>
    IQueryable<Service> FilterServices(IServiceQuery query);

    /// <summary>
    /// Filter
    /// </summary>
    /// <param name="query"></param>
    /// <param name="pagingParams"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IPagedList<Service>> GetPagedServicesByQueryAsync(IServiceQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get Service by Id
    /// </summary>
    /// <param name="id">Service's Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Service</returns>
    Task<Service> GetServiceByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>   
    /// Restore services from recycle bin
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> RestoreServicesAsync(int serviceId, CancellationToken cancellationToken = default);

    Task<IList<Service>> GetServicesAsync(CancellationToken cancellationToken = default);

    Task<bool> ChangeServiceDeleteStatusAsync(int id, CancellationToken cancellationToken = default);

    Task<Service> CreateServiceAsync(Service service, CancellationToken cancellationToken = default);
}