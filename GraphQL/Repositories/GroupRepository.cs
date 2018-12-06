using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmerRepository
    {

        public Task<Group> GetGroupAsync(int id)
        {
            return _dbContext.Groups.FindAsync(id);
        }

        public Group GetGroup(int id)
        {
            return _dbContext.Groups.FindAsync(id).Result;
        }

        public int NewGroupAsync(Group Group)
        {
            _dbContext.Groups.Add(Group);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<Group> UpdateGroup(int id, string name)
        {
            var c = _dbContext.Groups.FindAsync(id).Result;
            c.Name = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}