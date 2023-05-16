using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class UserTrackItem
{
    public Guid UserTrackItemId { get; set; }

    public Guid TrackItemId { get; set; }

    public Guid UserId { get; set; }

    public int Quantity { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public virtual TrackItem TrackItem { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserTrackItemHistory> UserTrackItemHistories { get; set; } = new List<UserTrackItemHistory>();
}
