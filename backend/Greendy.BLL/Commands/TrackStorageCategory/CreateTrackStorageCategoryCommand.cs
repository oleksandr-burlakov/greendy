using MediatR;

namespace Greendy.BLL.Commands.TrackStorageCategory;
public record CreateTrackStorageCategoryCommand(string Name, Guid StorageId) : IRequest;