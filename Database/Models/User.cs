using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.NodaTime;
using NodaTime;
using System.ComponentModel.DataAnnotations.Schema;
using CashmereServer.Database.Enums;

namespace CashmereServer.Database.Models
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        
        public int CreatedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreationTime { get; set; }
        public int ModifiedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ModifiedTime { get; set; }

        public string ExtendData { get; set; }
        
        public string Descriptions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [Required]
        public string Name { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string GivenName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public ESex Sex { get; set; }
    }
}