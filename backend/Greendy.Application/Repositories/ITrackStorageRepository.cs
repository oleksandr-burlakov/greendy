using Greendy.Domain.Entities;

namespace Greendy.Application.Repositories;
public interface ITrackStorageRepository 
{
    Task Delete(Guid TrackStorageId);
    Task<IEnumerable<TrackStorage>> GetByUserIdAsync(Guid UserId);
    Task UpdateAsync(TrackStorage trackStorage);
    Task<Guid> AddAsync(TrackStorage trackStorage);
    Task<TrackStorage> GetAsync(Guid TrackStorageId);
}
