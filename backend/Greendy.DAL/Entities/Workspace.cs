using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Entities
{
    public class Workspace
    {
        public Guid WorkspaceId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Workspace()
        {
        }

        public Workspace(string name, Guid ownerId)
        {
            WorkspaceId = Guid.NewGuid();
            OwnerId = ownerId;
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}