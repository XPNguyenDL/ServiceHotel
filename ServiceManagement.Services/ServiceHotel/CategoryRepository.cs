﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> ChangeCategoryDeleteStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Category>()
             .Where(c => c.Id == id)
             .ExecuteUpdateAsync(x => x.SetProperty(c => c.IsDeleted, c => !c.IsDeleted), cancellationToken) > 0;
    }

    public async Task<bool> ChangeCategoryAvailableStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Category>()
            .Where(s => s.Id == id)
            .ExecuteUpdateAsync(s => s.SetProperty(s => s.Available, s => !s.Available), cancellationToken) > 0;
    }

}