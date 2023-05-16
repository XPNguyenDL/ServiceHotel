using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.DTO;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;

namespace ServiceManagement.Services.ServiceHotel;

public class CategoryRepository : ICategoryRepository
{
    private readonly ServiceDbContext _context;

    public CategoryRepository(ServiceDbContext context)
    {
        this._context = context;
    }
    //U1.2 + U1.3 Thêm chỉnh sửa danh mục
	public async Task<bool> AddOrUpdateAsync(Category category, CancellationToken cancellationToken = default)
	{
		if (category.Id > 0)
		{
			_context.Categories.Update(category);
		}
		else
		{
			_context.Categories.Add(category);
		}

		return await _context.SaveChangesAsync(cancellationToken) > 0;
	}
    //U1.4 Xóa danh mục vào thùng rác + U1.7 Khôi phục danh mục từ thùng rác
	public async Task<bool> ChangeCategoryDeleteStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Category>()
             .Where(c => c.Id == id)
             .ExecuteUpdateAsync(x => x.SetProperty(c => c.IsDeleted, c => !c.IsDeleted), cancellationToken) > 0;
    }
    //U1.5 Xóa vĩnh viễn
	public async Task<bool> DeleteCategory(int id, CancellationToken cancellationToken = default)
	{
		return await _context.Categories
			.Where(x => x.Id == id)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}
    //U1.1 Hiển thị danh mục dịch vụ
	public async Task<IList<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default)
	{
        return await _context.Set<Category>()
            .Include(s => s.Services)
            .Select(c => new CategoryDto()
            {
                Name = c.Name,
                Description = c.Description,
                IsDeleted = c.IsDeleted,
                ServicesCount = c.Services.Count
            })
            .ToListAsync(cancellationToken);
	}

	public async Task<IList<Category>> GetDeletedCategoryAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Category>()
            .Where(x => x.IsDeleted == true)
            .ToListAsync(cancellationToken);
    }
}