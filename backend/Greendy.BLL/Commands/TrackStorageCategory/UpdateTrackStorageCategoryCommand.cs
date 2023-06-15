using MediatR;

namespace Greendy.BLL.Commands.TrackStorageCategory;
public record UpdateTrackStorageCategoryCommand(Guid Id, string Name) : IRequest;