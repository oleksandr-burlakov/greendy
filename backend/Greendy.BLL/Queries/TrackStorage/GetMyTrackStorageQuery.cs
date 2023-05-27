using MediatR;

namespace Greendy.BLL.Queries.TrackStorage;

public record GetMyTrackStorageQuery(string UserName) : IRequest<IEnumerable<GetMyTrackStorageResponse>>;

public record GetMyTrackStorageResponse(Guid TrackStorageId, string Name, string? Description);
