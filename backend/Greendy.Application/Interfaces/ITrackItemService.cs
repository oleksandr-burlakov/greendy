using Greendy.Application.DTO.TrackItem;

namespace Greendy.Application.Interfaces;
public interface ITrackItemService 
{
    Task<AddTrackItemResponse> AddAsync(AddTrackItemRequest request);
    Task<ICollection<GetByCategoryReponse>> GetByCategoryAsync(Guid categoryId);
}
