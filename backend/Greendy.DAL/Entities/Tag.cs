using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Entities
{
    public class Tag
    {
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Tag()
        {
        }
        public Tag(string name)
        {
            TagId = Guid.NewGuid();
            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}