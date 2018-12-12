using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CashmereServer.Database.Models
{
    public interface IBaseEntity
    {
        Guid Id{get; set;}
        Guid CreatorId{get; set;}        
        DateTime CreationTime {get; set;}
        Guid ModifierId{get; set;}
        DateTime ModifiedTime {get; set;}
        string Descriptions{get; set;}
        
        string Name{get; set;}
    }
}