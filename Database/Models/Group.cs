using System;
using System.Collections.Generic;

namespace CashmereServer.Database.Models
{
    public class Group : BaseEntity
    {
        public int[] AccountGroupIds { get; set; }
        public List<AccountGroup> AccountGroups { get; set; }
        
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}