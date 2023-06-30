using System;
using System.Collections.Generic;

namespace Greendy.Domain.Entities;

public partial class TrackStorageSubscription
{
	public Guid TrackStorageSubscriptionId { get; set; } = Guid.NewGuid();

    public Guid TrackStorageId { get; set; }

    public Guid UserId { get; set; }

    public virtual TrackStorage TrackStorage { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
