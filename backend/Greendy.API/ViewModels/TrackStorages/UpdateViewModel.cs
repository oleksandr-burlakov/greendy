using MediatR;

namespace Greendy.API.ViewModels.TrackStorages
{
	public record UpdateViewModel(Guid Id, string Name, string? Description)
		: IRequest;
}
