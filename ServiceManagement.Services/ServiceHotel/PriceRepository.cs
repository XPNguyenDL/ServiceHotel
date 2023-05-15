using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;

namespace ServiceManagement.Services.ServiceHotel;

public class PriceRepository : IPriceRepository {
    private readonly ServiceDbContext _context;

    public PriceRepository(ServiceDbContext context) {
        _context = context;
    }

    public async Task<Price> GetPriceByServiceIdAsync(int id, CancellationToken cancellationToken = default) {
        var priceHistory = await _context.Set<PriceHistory>()
            .Where(p => p.ServiceId == id)
            .FirstOrDefaultAsync(cancellationToken);

        return await _context.Set<Price>()
            .Where(p => p.Id == priceHistory.PriceId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Price> AddPriceAsync(Price price, CancellationToken cancellationToken = default) {
        await _context.Prices.AddAsync(price, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return price;
    }

    public async Task<PriceHistory> AddPriceHistoryAsync(PriceHistory priceHistory, CancellationToken cancellationToken = default) {
        await _context.PriceHistories.AddAsync(priceHistory, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return priceHistory;
    }

    public async Task<bool> DeletePriceByIdAsync(int id, CancellationToken cancellationToken = default) {
        return await _context.Set<Price>()
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken) > 0;
    }

    private async Task UpdatePriceHistoryAsync(int id, string note, CancellationToken cancellationToken = default) {
        await _context.Set<PriceHistory>()
            .Where(p => p.PriceId == id)
            .ExecuteUpdateAsync(p => p.SetProperty(p => p.ModifyTime, DateTime.Now), cancellationToken);

        await _context.Set<PriceHistory>()
            .Where(p => p.PriceId == id)
            .ExecuteUpdateAsync(p => p.SetProperty(p => p.Note, note), cancellationToken);
    }

    public async Task<Price> UpdatePriceAsync(Price price, string note, CancellationToken cancellationToken = default) {
        if (_context.Set<Price>().Any(p => p.Id == price.Id)) {
            _context.Entry(price).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            await UpdatePriceHistoryAsync(price.Id, note, cancellationToken);
        }

        return price;
    }
}