using MediatR;

namespace Greendy.BLL.Commands.TrackStorages
{
	public record DeleteTrackStorageCommand(Guid TrackStorageId, 
			string TrackStorageName) : IRequest;
}
