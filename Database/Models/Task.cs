using System;

namespace CashmereServer.Database.Models
{
    public class Task
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreationTime { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string ExtendData { get; set; }
        public string Descriptions { get; set; }

        public int AssignedToId { get; set; }
        public int WorkflowId { get; set; }
        public int ProductId { get; set; }
        public int TaskTemplateId { get; set; }
    }
}