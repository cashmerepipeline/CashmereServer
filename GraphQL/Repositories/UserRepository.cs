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

        public Task<User> GetUser(Guid id)
        {
            return _dbContext.Users.FindAsync(id);
        }

        public IEnumerable<User> GetUserByIds(IEnumerable<Guid> ids)
        {
            return _dbContext.Users.ToList().Where(a => ids.Contains(a.Id));
        }

        public int NewUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<User> UpdateUser(int id, string name)
        {
            var c = _dbContext.Users.FindAsync(id).Result;
            c.GivenName = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}