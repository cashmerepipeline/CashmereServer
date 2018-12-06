using System;
using System.Collections.Generic;

namespace CashmereServer.Database.Models
{
    public class Team:BaseEntity
    {
        public int[] AccountTeamIds { get; set; }
        public List<AccountTeam> AccountTeams { get; set; }
    }
}