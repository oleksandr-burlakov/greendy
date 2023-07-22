namespace Greendy.Application.DTO.TrackItem 
{
    public class AddTrackItemRequest 
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid? TrackItemCategoryId { get; set; }
        public string? ImagePath { get; set; }
        public byte[]? ImageBytes { get; set; }
    }
}