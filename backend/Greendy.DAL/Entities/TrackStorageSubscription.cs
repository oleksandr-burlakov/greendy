using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class TrackStorageSubscription
{
    public Guid TrackStorageSubscriptionId { get; set; }

    public Guid TrackStorageId { get; set; }

    public Guid UserId { get; set; }

    public virtual TrackStorage TrackStorage { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
