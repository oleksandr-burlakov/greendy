﻿namespace Greendy.DAL;

public partial class UserRole
{
    public Guid UserRoleId { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
