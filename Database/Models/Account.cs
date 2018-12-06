using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;

namespace CashmereServer.Database.Models
{
    public class Account : BaseEntity
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsHuman { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int[] TeamIds { get; set; }
        public int[] AccountTeamsIds { get; set; }
        public List<AccountTeam> AccountTeams { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}