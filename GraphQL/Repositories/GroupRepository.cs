using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {

        public Task<Group> GetGroupAsync(int id)
        {
            return _dbContext.Groups.FindAsync(id);
        }

        public Task<IEnumerable<Group>> GetGroupsAsync(int[] ids)
        {
            List<Group> result=null;
            foreach(var id in ids)
            {
                // IEnumerable<Group>
                result.Add( _dbContext.Groups.Find(id));
            }

            return result;
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