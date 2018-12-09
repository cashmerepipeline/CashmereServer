using System;

namespace CashmereServer.Database.Models
{
    public class AccountTeam
    {
        public Guid AccountId { get; set; }
        public Account Account{ get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}