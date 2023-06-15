using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class TrackItemCategory
{
    public Guid TrackItemCategoryId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public Guid? TrackStorageId { get; set; }
    public virtual ICollection<TrackItem> TrackItems { get; set; }
    public virtual TrackStorage? TrackStorage { get; set; }
}
