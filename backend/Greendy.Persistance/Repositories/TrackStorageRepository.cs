using Greendy.Application.Repositories;
using Greendy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greendy.Persistance.Repositories;
public class TrackStorageRepository : ITrackStorageRepository
{
    private readonly GreendyContext _context;
    public TrackStorageRepository(GreendyContext context)
    {
        _context = context; 
    }
    public async Task<Guid> AddAsync(TrackStorage trackStorage)
    {
        var item = (await _context.TrackStorages.AddAsync(trackStorage)).Entity;
        await _context.SaveChangesAsync();
        return item.TrackStorageId;
    }

    public async Task Delete(Guid TrackStorageId)
    {
        var item = await _context.TrackStorages.SingleAsync(x => x.TrackStorageId == TrackStorageId);
        _context.TrackStorages.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<TrackStorage> GetAsync(Guid trackStorageId)
    {
        return await _context.TrackStorages
            .AsNoTracking()
            .SingleAsync(x => x.TrackStorageId == trackStorageId);
    }

    public async Task<IEnumerable<TrackStorage>> GetByUserIdAsync(Guid userId)
    {
        return await _context.TrackStorages
            .AsNoTracking()
            .Where(ts => ts.AuthorId == userId)
            .ToListAsync();
    }

    public async Task UpdateAsync(TrackStorage trackStorage)
    {
        _context.Entry(trackStorage).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
