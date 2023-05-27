using Greendy.BLL.Commands.TrackStorages;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Greendy.BLL.Handlers.TrackStorageHandlers;

public class UpdateTrackStorageHandler : IRequestHandler<UpdateTrackStorageCommand>
{
    private readonly GreendyContext _db;

    public UpdateTrackStorageHandler(GreendyContext db)
    {
        _db = db;
    }
    public async Task Handle(UpdateTrackStorageCommand request, CancellationToken cancellationToken)
    {
        var item = await _db.TrackStorages.FirstOrDefaultAsync(i => i.TrackStorageId == request.StorageId);
        if (item != null)
        {
            item.Name = request.Name;
            item.Description = request.Description;
            await _db.SaveChangesAsync();
        }
    }
}