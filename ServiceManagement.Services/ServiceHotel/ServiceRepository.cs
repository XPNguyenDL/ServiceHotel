using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Contracts;
using ServiceManagement.Core.Entities;
using ServiceManagement.Core.Queries;
using ServiceManagement.Data.Contexts;
using ServiceManagement.Services.Extensions;

namespace ServiceManagement.Services.ServiceHotel;

public class ServiceRepository : IServiceRepository
{
	private readonly ServiceDbContext _context;

	public ServiceRepository(ServiceDbContext context)
	{
		_context = context;
	}

	public async Task<bool> DeleteServiceByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		return await _context.Set<Service>()
			.Where(s => s.Id == id && s.IsDeleted)
			.ExecuteDeleteAsync(cancellationToken) > 0;
	}

	public async Task<Service> UpdateServiceInfomationAsync(Service service, CancellationToken cancellationToken = default)
	{
		if (_context.Set<Service>().Any(s => s.Id == service.Id))
		{
			_context.Entry(service).State = EntityState.Modified;
			await _context.SaveChangesAsync(cancellationToken);
		}

		return service;
	}

	public async Task<bool> ToggleServiceAvailableStatusAsync(int id, CancellationToken cancellationToken = default)
	{
		return await _context.Set<Service>()
			.Where(s => s.Id == id)
			.ExecuteUpdateAsync(s => s.SetProperty(s => s.Available, s => !s.Available), cancellationToken) > 0;
	}

	public IQueryable<Service> FilterServices(IServiceQuery query)
	{
		IQueryable<Service> services = _context.Set<Service>();

		if (query.IsDeleted)
			services = services.Where(s => s.IsDeleted);
		if (!query.IsDeleted)
			services = services.Where(s => !s.IsDeleted);
		if (query.Available)
			services = services.Where(s => s.Available);
		if (!query.Available)
			services = services.Where(s => !s.Available);
		if (query.CategoryId > 0)
			services = services.Where(s => s.CategoryId == query.CategoryId);
		if (!string.IsNullOrWhiteSpace(query.Keyword))
			services = services.Where(s => s.Name.ToLower().Contains(query.Keyword.ToLower()) ||
			s.ShortDescription.ToLower().Contains(query.Keyword.ToLower()) ||
			s.Description.ToLower().Contains(query.Keyword.ToLower()));

		return services;
	}

	public async Task<IPagedList<Service>> GetPagedServicesByQueryAsync(IServiceQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default)
	{
		return await FilterServices(query).ToPagedListAsync(pagingParams, cancellationToken);
	}

	public async Task<bool> RestoreServicesAsync(int serviceId, CancellationToken cancellationToken = default)
	{
		return await _context.Services
			.Where(s => s.Id == serviceId)
			.ExecuteUpdateAsync(s => s.SetProperty(prop => prop.IsDeleted, true), cancellationToken) > 0;
	}
}