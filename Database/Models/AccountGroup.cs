using System;

namespace CashmereServer.Database.Models
{
    public class AccountGroup
    {
        public Guid AccountId { get; set; }
        public Account Account{ get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}