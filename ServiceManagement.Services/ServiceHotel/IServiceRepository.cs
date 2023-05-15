namespace ServiceManagement.Services.ServiceHotel;

public interface IServiceRepository {
    /// <summary>
    /// Delete permanently a Service by Id
    /// </summary>
    /// <param name="id">Service's Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Deleted status</returns>
    Task<bool> DeleteServiceByIdAsync(int id, CancellationToken cancellationToken = default);
}