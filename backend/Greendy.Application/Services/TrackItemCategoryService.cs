using Greendy.Application.DTO.TrackItemCategory;
using Greendy.Application.Interfaces;
using Greendy.Application.Repositories;
using Greendy.Domain.Entities;

namespace Greendy.Application.Services;
public class TrackItemCategoryService : ITrackItemCategoryService
{
    private readonly ITrackItemCategoryRepository _trackItemCategoryRepository;
    public TrackItemCategoryService(ITrackItemCategoryRepository trackItemCategoryRepository)
    {
        _trackItemCategoryRepository = trackItemCategoryRepository;
    }
    public async Task<Guid> AddAsync(AddTrackItemCategoryRequest request)
    {
        var trackItemCategory = new TrackItemCategory()
        {
            Name = request.Name,
            TrackStorageId = request.TrackStorageId
        };
        var id = await _trackItemCategoryRepository.AddAsync(trackItemCategory);
        return id;
    }

    public async Task DeleteAsync(Guid trackItemCategoryId)
    {
        await _trackItemCategoryRepository.DeleteAsync(trackItemCategoryId);
    }

    public async Task<IEnumerable<GetByTrackStorageResponse>> GetByTrackStorageAsync(Guid trackStorageId)
    {
        return (await _trackItemCategoryRepository.GetByTrackStorageAsync(trackStorageId))
            .Select(x => new GetByTrackStorageResponse(x.TrackItemCategoryId, x.Name));
    }

    public async Task UpdateAsync(UpdateTrackItemCategoryRequest request)
    {
        var trackItemCategory = await _trackItemCategoryRepository.GetAsync(request.TrackItemCategoryId);
        trackItemCategory.Name = request.Name;
        await _trackItemCategoryRepository.UpdateAsync(trackItemCategory);
    }
}
