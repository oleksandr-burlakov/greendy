using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class UserTrackItemHistory
{
    public Guid UserTrackItemHistoryId { get; set; } = Guid.NewGuid();

    public Guid UserTrackItemId { get; set; }

    public DateTime ExecutionDate { get; set; }

    public Guid UserTrackItemHistoryActionId { get; set; }

    public virtual UserTrackItem UserTrackItem { get; set; } = null!;

    public virtual UserTrackItemHistoryAction UserTrackItemHistoryAction { get; set; } = null!;
}
