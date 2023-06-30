using Greendy.Application.DTO.TrackStorage;
using Greendy.Domain.Entities;

namespace Greendy.Application.Interfaces;
public interface ITrackStorageService 
{
    Task<Guid> AddAsync(AddTrackStorageRequest request);
    Task DeleteAsync(Guid trackStorageId);
    Task<IEnumerable<GetMyTrackStorageResponse>> GetMyAsync(string username);
    Task UpdateAsync(UpdateTrackStorageRequest request);
}
