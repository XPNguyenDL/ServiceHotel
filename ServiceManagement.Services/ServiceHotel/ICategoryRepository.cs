namespace ServiceManagement.Services.ServiceHotel;

public interface ICategoryRepository
{
    Task<bool> ChangeCategoryDeleteStatusAsync(int id, CancellationToken cancellationToken = default);
}