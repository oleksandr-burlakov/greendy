using MediatR;

namespace Greendy.BLL.Queries.TrackStorageCategory;
public record GetTrackStorageCategoriesByStorageQuery(Guid TrackStorageId) : IRequest<ICollection<GetTrackStorageCategoriesByStorageResponse>>;

public record GetTrackStorageCategoriesByStorageResponse(Guid Id, string Name);