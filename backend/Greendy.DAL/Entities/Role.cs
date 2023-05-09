using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Role()
        {
        }
        public Role(string name)
        {
            RoleId = Guid.NewGuid();
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}