using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class UserTrackItemHistoryAction
{
    public Guid UserTrackItemHistoryActionId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public virtual UserTrackItemHistory? UserTrackItemHistory { get; set; }
}
