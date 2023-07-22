namespace Greendy.API.ViewModels.TrackItem
{
    public class AddTrackItemRequest 
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid TrackItemCategoryId { get; set; }
        public IFormFile? Image { get; set; }
    }
}