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

        public Task<Group> GetGroup(Guid id)
        {
            return _dbContext.Groups.FindAsync(id);
        }
        
        public IEnumerable<Group> GetGroupByIds(IEnumerable<Guid> ids)
        {
            return _dbContext.Groups.ToList().Where(a => ids.Contains(a.Id));
        }

        public int NewGroup(Group Group)
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