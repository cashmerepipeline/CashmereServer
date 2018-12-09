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

        public string[] AccountGroupIds { get; set; }
        public List<AccountGroup> AccountGroups { get; set; } // not in graphql

        public string[] AccountTeamIds { get; set; }
        public List<AccountTeam> AccountTeams { get; set; } // not in graphql

        public string UserId { get; set; }
        public User User { get; set; }

        // graphql only
        [NotMapped]
        public List<Group> Groups { get; set; }
        [NotMapped]
        public List<Team> Teams { get; set; }
    }
}