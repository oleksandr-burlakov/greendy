using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class TrackStorage
{
    public Guid TrackStorageId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime LastModifiedDate { get; set; }
    public virtual User Author { get; set; } = null!;
    public virtual ICollection<TrackItemCategory> TrackItemCategories {get; set;} = new List<TrackItemCategory>();
    public virtual ICollection<TrackStorageItem> TrackStorageItems { get; set; } = new List<TrackStorageItem>();
    public virtual ICollection<TrackStorageSubscription> TrackStorageSubscriptions { get; set; } = new List<TrackStorageSubscription>();
}
