using System;
using System.Collections.Generic;

namespace Greendy.DAL;

public partial class Role
{
    public Guid RoleId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
