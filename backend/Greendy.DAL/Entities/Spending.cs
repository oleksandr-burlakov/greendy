using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greendy.DAL.Entities
{
    public class Spending
    {
        public Guid SpendingId { get; set; }
        public Guid UserId { get; set; }
        public Guid WorkspaceId { get; set; }
        public float Amount { get; set; }
        public DateTime SpendingDate { get; set; }
        public string? Reason { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Spending()
        {
        }
        public Spending(Guid userId, Guid workspaceId, float amount, DateTime? spendingDate, string? reason, Guid? categoryId)
        {
            UserId = userId;
            WorkspaceId = workspaceId;
            Amount = amount;
            Reason = reason;
            CategoryId = categoryId;
            SpendingDate = spendingDate ?? DateTime.Now;
            SpendingId = Guid.NewGuid();
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}