using Greendy.Application.DTO.TrackStorage;
using Greendy.Application.Interfaces;
using Greendy.Application.Repositories;
using Greendy.Domain.Entities;

namespace Greendy.Application.Services;
public class TrackStorageService : ITrackStorageService
{
    private readonly ITrackStorageRepository _trackRepository;
    private readonly IUserRepository _userRepository;
    public TrackStorageService(ITrackStorageRepository trackRepository,
        IUserRepository userRepository)
    {
        _trackRepository = trackRepository; 
        _userRepository = userRepository;
    }
    public async Task<Guid> AddAsync(AddTrackStorageRequest request)
    {
        var user = await _userRepository.GetByLoginAsync(request.AuthorName);
        var trackStorage = new TrackStorage()
        {
            AuthorId = user!.UserId,
            Description = request.Description,
            Name = request.Name,
        };
        var id = await _trackRepository.AddAsync(trackStorage);
        return id;
    }

    public async Task DeleteAsync(Guid trackStorageId)
    {
        await _trackRepository.Delete(trackStorageId);
    }

    public async Task UpdateAsync(UpdateTrackStorageRequest request)
    {
        var trackStorage = await _trackRepository.GetAsync(request.TrackStorageId);
        trackStorage.Name = request.Name;
        trackStorage.Description = request.Description;
        await _trackRepository.UpdateAsync(trackStorage);
    }

    public async Task<IEnumerable<GetMyTrackStorageResponse>> GetMyAsync(string username)
    {
        var user = await _userRepository.GetByLoginAsync(username);
        return (await _trackRepository.GetByUserIdAsync(user!.UserId))
            .Select(x => new GetMyTrackStorageResponse(x.TrackStorageId, x.Name, x.Description));
    }
}
