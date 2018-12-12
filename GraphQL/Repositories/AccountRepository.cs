using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using CashmereServer.Database.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using GreenDonut;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {

        public Task<Account> GetAccountAsync(string id)
        {
            return _dbContext.Accounts.FindAsync(id);
        }

        public Task<Account> GetAccount(string id)
        {
            return _dbContext.Accounts.FindAsync(id);
        }

        public IEnumerable<Account> GetAccountByIds(IEnumerable<string> ids)
        {
            return _dbContext.Accounts.ToList().Where(a => ids.Contains(a.Id));
            // var result = _dbContext.Accounts.ToList().Where(a=>ids.Contains(a.Id));
            // return System.Threading.Tasks.Task.FromResult<IEnumerable<Account>>(result);
        }

        public int NewAccountAsync(Account account)
        {
            try
            {   
                var a_id =  new Guid();
                account.Id = a_id.ToString();

                var utcNow = DateTime.UtcNow;
                account.CreationTime = utcNow.ToLocalTime();
                account.ModifiedTime = utcNow;

                account.CreatorId = account.Id.ToString();
                account.ModifierId = account.Id;
                account.IsHuman = true;
                account.AccountGroupIds=new string[]{};
                account.AccountTeamIds=new string[]{};

                var user = new User();
                var u_id = new Guid();
                user.Id = u_id.ToString();
                user.CreatorId = account.Id.ToString();
                user.ModifierId = account.Id;

                user.CreationTime = utcNow;
                user.ModifiedTime = utcNow;

                user.Name = "defaultName";
                user.FamilyName = "defaultFamily";
                user.GivenName = "defaultGiven";
                user.BirthDate = utcNow.Date;
                user.Sex = ESex.male;

                account.User = user;

                // account.CreatorId = currentUserId;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                
                _dbContext.Accounts.Add(account);

                Console.WriteLine("{0}, {1}, {2}, {3}",
                                    account.Id, account.ModifiedTime, account.PhoneNumber, account.IsHuman);

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
            foreach (var key in properties.Keys)
            {
                if (account.GetType().GetProperty(key) != null)
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