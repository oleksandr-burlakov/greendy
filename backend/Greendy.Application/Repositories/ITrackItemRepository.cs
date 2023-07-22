using Greendy.Domain.Entities;

namespace Greendy.Application.Repositories;
public interface ITrackItemRepository 
{
    Task<Guid> AddAsync(TrackItem trackItem);
    Task<ICollection<TrackItem>> GetByCategoryAsync(Guid categoryId);
}
