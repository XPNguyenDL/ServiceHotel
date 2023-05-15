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
}