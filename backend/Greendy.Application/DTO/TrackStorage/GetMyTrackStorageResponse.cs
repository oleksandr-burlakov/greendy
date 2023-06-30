namespace Greendy.Application.DTO.TrackStorage;
public record GetMyTrackStorageResponse(Guid TrackStorageId, string Name, string? Description);