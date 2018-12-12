using System;

namespace CashmereServer.Database.Models
{
    public class Task : BaseEntity
    {
        public Guid AssignedToId { get; set; }
        public Guid WorkflowId { get; set; }
        public Guid AchievementId { get; set; }
        public Guid TaskTemplateId { get; set; }
    }
}