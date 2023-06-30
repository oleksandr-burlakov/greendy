using Greendy.Application.Repositories;
using Greendy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greendy.Persistance.Repositories;
public class TrackItemCategoryRepository : ITrackItemCategoryRepository
{
    private readonly GreendyContext _context;
    public TrackItemCategoryRepository(GreendyContext context)
    {
        _context = context;   
    }
    public async Task<Guid> AddAsync(TrackItemCategory trackItemCategory)
    {
        var item = (await _context.TrackItemCategories.AddAsync(trackItemCategory)).Entity;
        await _context.SaveChangesAsync();
        return item.TrackItemCategoryId;
    }

    public async Task DeleteAsync(Guid trackItemCategoryId)
    {
        var item = await _context.TrackItemCategories.SingleAsync(i => i.TrackItemCategoryId == trackItemCategoryId);
        _context.TrackItemCategories.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<TrackItemCategory?> GetAsync(Guid trackItemCategoryId)
    {
        return await _context.TrackItemCategories.FirstOrDefaultAsync(i => i.TrackItemCategoryId == trackItemCategoryId);
    }

    public async Task<IEnumerable<TrackItemCategory>> GetByTrackStorageAsync(Guid trackStorageId)
    {
        return await _context.TrackItemCategories
            .Where(i => i.TrackStorageId == trackStorageId)
            .ToListAsync();
    }

    public async Task UpdateAsync(TrackItemCategory trackItemCategory)
    {
        _context.Entry(trackItemCategory).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
