using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashmereServer.Database.Models
{
    public class Group : BaseEntity
    {
        public Guid[] AccountGroupIds { get; set; }
        public List<AccountGroup> AccountGroups { get; set; }

        // graphql only
        [NotMapped]
        public List<Account> Accounts { get; set; }
    }
}