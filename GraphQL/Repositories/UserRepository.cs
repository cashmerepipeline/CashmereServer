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

        public Task<User> GetUserAsync(int id)
        {
            return _dbContext.User.FindAsync(id);
        }

        public User GetUser(int id)
        {
            return _dbContext.User.FindAsync(id).Result;
        }

        public int NewUserAsync(User user)
        {
            _dbContext.User.Add(user);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<User> UpdateUser(int id, string name)
        {
            var c = _dbContext.User.FindAsync(id).Result;
            c.GivenName = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}