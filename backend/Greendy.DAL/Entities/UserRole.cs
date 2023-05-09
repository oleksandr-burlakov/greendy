using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Entities
{
    public class UserRole
    {
        public Guid UserRoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public UserRole()
        {
        }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
            UserRoleId = Guid.NewGuid();
        }
    }
}