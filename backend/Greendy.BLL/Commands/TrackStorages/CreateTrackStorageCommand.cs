using MediatR;

namespace Greendy.BLL.Commands.TrackStorages
{
	public record CreateStorageCommand(string Name, string? Description, 
			string AuthorName) : IRequest<Guid>;
}
