namespace Greendy.Application.DTO.TrackStorage;
public record UpdateTrackStorageRequest(Guid TrackStorageId, string Name, string? Description);