using System;
using System.Collections.Generic;

namespace CashmereServer.Database.Models
{
    public class Group : BaseEntity
    {
        public List<Account> Accounts { get; set; }
        
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}