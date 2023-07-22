using System.Runtime.CompilerServices;
using Greendy.Application.DTO.TrackItem;
using Greendy.Application.Helpers;
using Greendy.Application.Interfaces;
using Greendy.Application.Repositories;

namespace Greendy.Application.Services;
public class TrackItemService : ITrackItemService
{
    private readonly ITrackItemRepository _trackItemRepository;

    public TrackItemService(ITrackItemRepository trackItemRepository)
    {
        _trackItemRepository = trackItemRepository;
    }

    public async Task<AddTrackItemResponse> AddAsync(AddTrackItemRequest request)
    {
        var fileHelper = new FileHelper();
        string? imagePath = null;
        if (request.ImageBytes != null && request.ImageBytes.Any() && request.ImagePath != null)
        {
            imagePath = await fileHelper.SaveFile(request.ImagePath, request.ImageBytes);
        }
        var id = await _trackItemRepository.AddAsync(new Domain.Entities.TrackItem() {
          Description = request.Description,
          Name = request.Name,
          ImagePath = imagePath,
          LastModifiedDate = DateTime.UtcNow,
          TrackItemCategoryId = request.TrackItemCategoryId
        });
        return new AddTrackItemResponse() {
            TrackItemId = id,
            FilePath = imagePath
        };
    }

    public async Task<ICollection<GetByCategoryReponse>> GetByCategoryAsync(Guid categoryId)
    {
        var trackItems = (await _trackItemRepository.GetByCategoryAsync(categoryId))
            .Select(i => new GetByCategoryReponse() {
                Name = i.Name,
                Description = i.Description,
                ImagePath = i.ImagePath,
                TrackItemCategoryId = i.TrackItemCategoryId.Value,
                TrackItemId = i.TrackItemId,
            })
            .ToList();
        return trackItems;
    }
}