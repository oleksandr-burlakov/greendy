using System.Security.Cryptography.X509Certificates;
using Greendy.BLL.Commands.TrackStorageCategory;
using Greendy.DAL;
using MediatR;

namespace Greendy.BLL.Handlers.TrackStorageCategoryHandlers;
public class UpdateTrackStorageCategoryHandler : IRequestHandler<UpdateTrackStorageCategoryCommand>
{
    private readonly GreendyContext _db;
    public UpdateTrackStorageCategoryHandler(GreendyContext db)
    {
        _db = db;
    }
    public async Task Handle(UpdateTrackStorageCategoryCommand request, CancellationToken cancellationToken)
    {
        var item = _db.TrackItemCategories.Single(c => c.TrackItemCategoryId == request.Id);
        item.Name = request.Name;
        await _db.SaveChangesAsync(cancellationToken);
    }
}
