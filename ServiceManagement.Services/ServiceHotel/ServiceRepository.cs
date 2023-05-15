using Azure;
using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;
using static ServiceManagement.Services.ServiceHotel.ServiceRepository;

namespace ServiceManagement.Services.ServiceHotel;

public class ServiceRepository : IServiceRepository
{
    private readonly ServiceDbContext _context;

    public ServiceRepository(ServiceDbContext context)
    {
        this._context = context;
    }


    // U2.1 Xem thông tin dịch vụ
    public async Task<IList<Service>> GetServicesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Service>()
            .Include(c => c.Category)
            .ToListAsync(cancellationToken);
    }


    // U2.2 Thêm dịch vụ
    public async Task<Service> CreateServiceAsync(Service service,CancellationToken cancellationToken = default)
    {

        if (_context.Set<Service>().Any(s => s.Id != service.Id))
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return service;
    }


    // U2.3 Xóa dịch vụ vào thùng rác
    public async Task<bool> ChangeServiceDeleteStatusAsync(int id, CancellationToken cancellationToken = default)
    {
       return await _context.Set<Service>()
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.IsDeleted, p => !p.IsDeleted), cancellationToken) > 0;
    }

}
  