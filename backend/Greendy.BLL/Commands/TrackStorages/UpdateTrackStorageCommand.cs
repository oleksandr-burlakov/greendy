using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Greendy.BLL.Commands.TrackStorages
{
    public record UpdateTrackStorageCommand(Guid StorageId, string Name, string? Description) : IRequest;
}
