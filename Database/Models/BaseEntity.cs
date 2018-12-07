using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashmereServer.Database.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; set; }

        public int CreatorId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName="timestamp with time zone")]
        public DateTime CreationTime { get; set; }
        
        public int ModifierId { get; set; }

        [Timestamp]
        [Column(TypeName="timestamp with time zone")]
        public DateTime ModifiedTime { get; set; }

        public string Name { get; set; }
        public string Descriptions { get; set; }
    }
}