using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {

        public Task<Account> GetAccountAsync(int id)
        {
            return _dbContext.Accounts.FindAsync(id);
        }

        public Account GetAccount(int id)
        {
            return _dbContext.Accounts.FindAsync(id).Result;
        }

        public int NewAccountAsync(Account Account)
        {
            _dbContext.Accounts.Add(Account);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<Account> UpdateAccount(int id, string name)
        {
            var c = _dbContext.Accounts.FindAsync(id).Result;
            c.Name = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}