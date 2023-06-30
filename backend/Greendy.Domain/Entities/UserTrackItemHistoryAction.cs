using System;
using System.Collections.Generic;

namespace Greendy.Domain.Entities;

public partial class UserTrackItemHistoryAction
{
    public Guid UserTrackItemHistoryActionId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public virtual UserTrackItemHistory? UserTrackItemHistory { get; set; }
}
