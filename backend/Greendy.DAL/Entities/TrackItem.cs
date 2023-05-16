using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class TrackItem
{
    public Guid TrackItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid? TrackItemCategoryId { get; set; }

    public string? ImagePath { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public virtual TrackItemCategory? TrackItemCategory { get; set; }

    public virtual ICollection<TrackStorageItem> TrackStorageItems { get; set; } = new List<TrackStorageItem>();

    public virtual ICollection<UserTrackItem> UserTrackItems { get; set; } = new List<UserTrackItem>();
}
