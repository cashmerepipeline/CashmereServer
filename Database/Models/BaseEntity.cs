using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashmereServer.Database.Models
{
    public abstract class BaseEntity : IBaseEntity
    {   
        [Key]
        public Guid Id { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public Guid Uuid { get; set; }

        public Guid CreatorId { get; set; }

        // [Column(TypeName="timestamp with time zone")]
        public DateTime CreationTime { get; set; }
        
        public Guid ModifierId { get; set; }

        [Timestamp]
        // [Column(TypeName="timestamp with time zone")]
        public DateTime ModifiedTime { get; set; }

        public string Name { get; set; }
        public string Descriptions { get; set; }

         // graphql only
        [NotMapped]
        public Account Creator { get; set; }
        [NotMapped]
        public Account Modifier {get; set;}
    }
}