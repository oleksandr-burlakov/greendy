using Greendy.BLL.Queries.TrackStorageCategory;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Greendy.BLL.Handlers.TrackStorageCategoryHandlers;
public class GetTrackStorageCategoriesByStorageHandler : IRequestHandler<GetTrackStorageCategoriesByStorageQuery, ICollection<GetTrackStorageCategoriesByStorageResponse>>
{
    private readonly GreendyContext _db;

    public GetTrackStorageCategoriesByStorageHandler(GreendyContext db)
    {
       _db = db; 
    }
    public async Task<ICollection<GetTrackStorageCategoriesByStorageResponse>> Handle(GetTrackStorageCategoriesByStorageQuery request, CancellationToken cancellationToken)
    {
        return (await _db.TrackItemCategories.Where(x => x.TrackStorageId == request.TrackStorageId)
            .Select(x => new GetTrackStorageCategoriesByStorageResponse(x.TrackItemCategoryId, x.Name))
            .ToListAsync(cancellationToken));
    }
}
