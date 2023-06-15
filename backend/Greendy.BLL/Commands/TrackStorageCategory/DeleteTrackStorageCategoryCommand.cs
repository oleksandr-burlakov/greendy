using MediatR;

namespace Greendy.BLL.Commands.TrackStorageCategory;
public record DeleteTrackStorageCategoryCommand(Guid Id) : IRequest;