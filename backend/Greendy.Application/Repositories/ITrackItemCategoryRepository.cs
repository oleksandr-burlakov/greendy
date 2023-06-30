using Greendy.Domain.Entities;

namespace Greendy.Application.Repositories;
public interface ITrackItemCategoryRepository 
{
    Task<Guid> AddAsync(TrackItemCategory trackItemCategory);
    Task DeleteAsync(Guid trackItemCategoryId);
    Task UpdateAsync(TrackItemCategory trackItemCategory);
    Task<TrackItemCategory?> GetAsync(Guid trackItemCategoryId);
    Task<IEnumerable<TrackItemCategory>> GetByTrackStorageAsync(Guid trackStorageId);
}
