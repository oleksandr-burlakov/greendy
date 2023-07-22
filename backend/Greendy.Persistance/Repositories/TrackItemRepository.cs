using Greendy.Application.Repositories;
using Greendy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greendy.Persistance.Repositories;
public class TrackItemRepository : ITrackItemRepository
{
    private readonly GreendyContext _context;
    public TrackItemRepository(GreendyContext context)
    {
        _context = context;
    }
    public async Task<Guid> AddAsync(TrackItem trackItem)
    {
        var item = (await _context.TrackItems.AddAsync(trackItem)).Entity;
        await _context.SaveChangesAsync();
        return item.TrackItemId;
    }

    public async Task<ICollection<TrackItem>> GetByCategoryAsync(Guid categoryId)
    {
        return await _context.TrackItems
            .Where(ti => ti.TrackItemCategoryId == categoryId)
            .ToListAsync();
    }
}
