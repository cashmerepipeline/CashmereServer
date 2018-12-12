using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {

        public Task<Group> GetGroupAsync(Guid id)
        {
            return _dbContext.Groups.FindAsync(id);
        }

        public Task<List<Group>> GetGroupsAsync(Guid[] ids)
        {
            var result = _dbContext.Groups.Where(g => ids.Contains(g.Id)).ToListAsync();

            return result;
        }

        public Group GetGroup(Guid id)
        {
            return _dbContext.Groups.FindAsync(id).Result;
        }

        public int NewGroupAsync(Group Group)
        {
            _dbContext.Groups.Add(Group);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<Group> UpdateGroup(Guid id, string name)
        {
            var c = _dbContext.Groups.FindAsync(id).Result;
            c.Name = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}