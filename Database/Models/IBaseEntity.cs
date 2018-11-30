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
        
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        DateTime CreationTime {get; set;}

        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        DateTime ModifyTime {get; set;}

        [Column(TypeName="jsonb")]
        string ExtendData { get; set; }
    }
}