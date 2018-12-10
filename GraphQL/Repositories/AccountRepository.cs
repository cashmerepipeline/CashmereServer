using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using GreenDonut;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {

        public Task<Account> GetAccountAsync(Guid id)
        {
            return _dbContext.Accounts.FindAsync(id);
        }

        public Account GetAccount(Guid id)
        {
            return _dbContext.Accounts.FindAsync(id).Result;
        }

        public IAsyncEnumerable<Account> GetAccountByIds(IReadOnlyList<Guid> ids)
        {
            return _dbContext.Accounts.ToAsyncEnumerable().Where(a=>ids.Contains(a.Id));
        }

        // public Task<IReadOnlyList<IResult<Account>>> GetAccountByIds(IReadOnlyList<Guid> ids)
        // {
        //     var results =  _dbContext.Accounts.ToList().Where(a=>ids.Contains(a.Id));
        //     var tsk = new Task<IEnumerable<Account>>(()=>{
        //         return results;
        //     });
            
        //     return tsk;

        // }

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