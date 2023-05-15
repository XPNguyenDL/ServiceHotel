using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;

namespace ServiceManagement.Services.ServiceHotel;

public class ServiceRepository : IServiceRepository {
    private readonly ServiceDbContext _context;

    public ServiceRepository(ServiceDbContext context) {
        _context = context;
    }

    public async Task<bool> DeleteServiceByIdAsync(int id, CancellationToken cancellationToken = default) {
        return await _context.Set<Service>()
            .Where(s => s.Id == id && s.IsDeleted)
            .ExecuteDeleteAsync(cancellationToken) > 0;
    }

    public async Task<Service> UpdateServiceInfomationAsync(Service service, CancellationToken cancellationToken = default) {
        if (_context.Set<Service>().Any(s => s.Id == service.Id))
            _context.Entry(service).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);

        return service;
    }
}