using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class TrackStorageItem
{
    public Guid TrackStorageItemId { get; set; }

    public Guid TrackStorageId { get; set; }

    public Guid TrackItemId { get; set; }

    public virtual TrackItem TrackItem { get; set; } = null!;

    public virtual TrackStorage TrackStorage { get; set; } = null!;
}
