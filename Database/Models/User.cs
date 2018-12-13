using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ComponentModel.DataAnnotations.Schema;
using CashmereServer.Database.Enums;

namespace CashmereServer.Database.Models
{
    public class User : BaseEntity
    {  
        [Required]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string GivenName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public ESex Sex { get; set; }
    }
}