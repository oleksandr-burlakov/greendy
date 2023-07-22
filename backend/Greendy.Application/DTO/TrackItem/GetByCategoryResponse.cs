namespace Greendy.Application.DTO.TrackItem
{
    public class GetByCategoryReponse 
    {
        public Guid TrackItemId { get; set; }
        public Guid TrackItemCategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}