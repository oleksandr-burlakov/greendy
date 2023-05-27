using Greendy.BLL.Commands.TrackStorages;
using Greendy.DAL;
using MediatR;

namespace Greendy.BLL.Handlers.TrackStorageHandlers
{
    public class CreateItemStorageHandler : IRequestHandler<CreateStorageCommand, Guid>
    {
		private readonly GreendyContext _db;
		
		public CreateItemStorageHandler(GreendyContext db)
		{
			_db = db;	
		}

        public async Task<Guid> Handle(CreateStorageCommand request, 
				CancellationToken cancellationToken)
        {
			var author = _db.Users.Single(u => u.UserName == request.AuthorName);
			TrackStorage itemStorage = new() {
				Name = request.Name,
				AuthorId = author.UserId,
				Description = request.Description
			};
			await _db.TrackStorages.AddAsync(itemStorage);
			await _db.SaveChangesAsync();
			return itemStorage.TrackStorageId;
        }
    }
}
