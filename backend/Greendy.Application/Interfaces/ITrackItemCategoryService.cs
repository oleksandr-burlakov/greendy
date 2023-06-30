using Greendy.Application.DTO.TrackItemCategory;

namespace Greendy.Application.Interfaces;
public interface ITrackItemCategoryService 
{
    Task<Guid> AddAsync(AddTrackItemCategoryRequest request);
    Task DeleteAsync(Guid trackItemCategoryId);
    Task<IEnumerable<GetByTrackStorageResponse>> GetByTrackStorageAsync(Guid trackStorageId);
    Task UpdateAsync(UpdateTrackItemCategoryRequest request);
}
