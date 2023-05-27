using Greendy.BLL.Commands.TrackStorages;
using Greendy.BLL.Exceptions;
using Greendy.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Greendy.BLL.Handlers.TrackStorageHandlers {
	public class DeleteTrackStorageHandler : 
		IRequestHandler<DeleteTrackStorageCommand>
	{
		private readonly GreendyContext _db;
		public DeleteTrackStorageHandler(GreendyContext db)
		{
			_db = db;	
		}

        public async Task Handle(DeleteTrackStorageCommand request, CancellationToken cancellationToken)
        {
			var trackStorage = await _db.TrackStorages.SingleAsync(x => x.TrackStorageId == 
					request.TrackStorageId);
			if (trackStorage.Name != request.TrackStorageName)
			{
				throw new IncorrectTrackStorageNameException("You wrote " +
					"incorrect track storage name");
			}
			_db.TrackStorages.Remove(trackStorage);
			await _db.SaveChangesAsync();
        }
    }
}
