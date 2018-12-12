using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashmereServer.Database.Models
{
    public class Team : BaseEntity
    {
        public Guid[] AccountTeamIds { get; set; }
        public List<AccountTeam> AccountTeams { get; set; }

        // graphql only
        [NotMapped]
        public List<Account> Accounts { get; set; }
    }
}