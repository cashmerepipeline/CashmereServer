using System.Threading.Tasks;
using System.Threading;
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

        public Task<Account> GetAccount(Guid id)
        {
            return _dbContext.Accounts.FindAsync(id);
        }

        public IEnumerable<Account> GetAccountByIds(IEnumerable<Guid> ids)
        {
            return _dbContext.Accounts.ToList().Where(a=>ids.Contains(a.Id));
            // var result = _dbContext.Accounts.ToList().Where(a=>ids.Contains(a.Id));
            // return System.Threading.Tasks.Task.FromResult<IEnumerable<Account>>(result);
        }

        public int NewAccountAsync(Account account)
        {
            try
            {   
                account.Id = new Guid();

                var utcNow = DateTime.UtcNow;
                account.CreationTime = utcNow;
                account.ModifiedTime = utcNow;
                
                account.CreatorId = account.Id;
                account.ModifierId = account.Id;

                account.UserId = new Guid();

                // account.CreatorId = currentUserId;
                _dbContext.Accounts.Add(account);
                var result = _dbContext.SaveChanges();
                
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
           
        }

        internal async Task<Account> UpdateAccount(int id, Dictionary<string, dynamic> properties)
        {
            var account = _dbContext.Accounts.Find(id);
            foreach(var key in properties.Keys)
            {
                if(account.GetType().GetProperty(key) != null)
                {
                    var property = account.GetType().GetProperty(key);
                    property.SetValue(property, properties.GetValueOrDefault(key));
                }
            }
            
            await _dbContext.SaveChangesAsync();
            return account;
        }
    }
}