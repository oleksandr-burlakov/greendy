using Greendy.BLL.Commands.TrackStorageCategory;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Greendy.BLL.Handlers.TrackStorageCategoryHandlers;
public class DeleteTrackStorageCategoryHandler : IRequestHandler<DeleteTrackStorageCategoryCommand>
{
    private readonly GreendyContext _db;
    public DeleteTrackStorageCategoryHandler(GreendyContext db)
    {
       _db = db; 
    }
    public async Task Handle(DeleteTrackStorageCategoryCommand request, CancellationToken cancellationToken)
    {
        var item = await _db.TrackItemCategories.SingleAsync(i => i.TrackItemCategoryId == request.Id, cancellationToken);
        _db.TrackItemCategories.Remove(item);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
