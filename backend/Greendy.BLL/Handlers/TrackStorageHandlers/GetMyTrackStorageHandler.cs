using Greendy.BLL.Queries.TrackStorage;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Greendy.BLL.Handlers.TrackStorageHandlers;

public class GetMyTrackStorageHandler : IRequestHandler<GetMyTrackStorageQuery, IEnumerable<GetMyTrackStorageResponse>>
{
    private readonly GreendyContext _db;

    public GetMyTrackStorageHandler(GreendyContext db)
    {
        _db = db;
    }
    public async Task<IEnumerable<GetMyTrackStorageResponse>> Handle(GetMyTrackStorageQuery request, CancellationToken cancellationToken)
    {
        var user = await _db.Users.SingleAsync(x => x.UserName == request.UserName);
        return (await _db.TrackStorages.Where(ts => ts.AuthorId == user.UserId)
                .Select(x => new GetMyTrackStorageResponse(x.TrackStorageId, x.Name, x.Description))
                .ToListAsync());
    }
}