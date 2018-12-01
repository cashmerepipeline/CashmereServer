using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.NodaTime;
using NodaTime;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CashmereServer.Database.Models
{
    public interface IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id{get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Guid Uuid{get; set;}

        string Name{get; set;}

        int CreatedById{get; set;}
                
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        DateTime CreationTime {get; set;}

        int ModifiedById{get; set;}
        
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        DateTime ModifiedTime {get; set;}

        [Column(TypeName="jsonb")]
        string ExtendData { get; set; }

        string Descriptions{get; set;}
    }
}