using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Entities
{
    public class SpendingTag
    {
        public Guid SpendingTagId { get; set; }
        public Guid SpendingId { get; set; }
        public Guid TagId { get; set; }
        public SpendingTag()
        {
        }

        public SpendingTag(Guid spendingId, Guid tagId)
        {
            SpendingId = spendingId;
            TagId = tagId;
            SpendingTagId = Guid.NewGuid();
        }
    }
}