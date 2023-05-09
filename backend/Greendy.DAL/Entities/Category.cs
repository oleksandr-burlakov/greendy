namespace Greendy.DAL.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Category()
        {
        }
        public Category(string name)
        {
            CategoryId = Guid.NewGuid();
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}