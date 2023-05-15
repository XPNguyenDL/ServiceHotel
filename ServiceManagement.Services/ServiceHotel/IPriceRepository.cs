using ServiceManagement.Core.Entities;

namespace ServiceManagement.Services.ServiceHotel;

public interface IPriceRepository {
    /// <summary>
    /// Get Price by Service id
    /// </summary>
    /// <param name="id">Service's Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Service Price</returns>
    Task<Price> GetPriceByServiceIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new Price when adding new Service
    /// </summary>
    /// <param name="price">New Price</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Added Price</returns>
    Task<Price> AddPriceAsync(Price price, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new PriceHistory when adding new Service
    /// </summary>
    /// <param name="priceHistory">New PriceHistory</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Added PriceHistory</returns>
    Task<PriceHistory> AddPriceHistoryAsync(PriceHistory priceHistory, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete Price by Id
    /// </summary>
    /// <param name="id">Price's Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Deleted status</returns>
    Task<bool> DeletePriceByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update Serivce price
    /// </summary>
    /// <param name="price">New Price</param>
    /// <param name="note">Update note</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Updated Price</returns>
    Task<Price> UpdatePriceAsync(Price price, string note, CancellationToken cancellationToken = default);
}