using ServiceManagement.Core.DTO;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Services.ServiceHotel;

public interface ICategoryRepository
{
    Task<bool> ChangeCategoryDeleteStatusAsync(int id, CancellationToken cancellationToken = default);

    Task<IList<Category>> GetDeletedCategoryAsync(CancellationToken cancellationToken = default);

    Task<IList<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default);


    Task<bool> AddOrUpdateAsync(Category category, CancellationToken cancellationToken = default);

    Task<bool> DeleteCategory(int id, CancellationToken cancellationToken = default);
}