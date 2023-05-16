using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class TrackItemCategory
{
    public Guid TrackItemCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public virtual ICollection<TrackItem> TrackItems { get; set; } = new List<TrackItem>();
}
