using Greendy.BLL.Commands.TrackStorageCategory;
using Greendy.DAL;
using MediatR;

namespace Greendy.BLL.Handlers.TrackStorageCategoryHandlers;
public class CreateTrackStorageCategoryHandler : IRequestHandler<CreateTrackStorageCategoryCommand>
{
    private readonly GreendyContext _db;
    public CreateTrackStorageCategoryHandler(GreendyContext db)
    {
        _db = db;
    }
    public async Task Handle(CreateTrackStorageCategoryCommand request, CancellationToken cancellationToken)
    {
        await _db.TrackItemCategories.AddAsync(new TrackItemCategory() {
            Name = request.Name,
            TrackStorageId = request.StorageId
        }, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
