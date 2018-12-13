using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.DataLoaders;
using HotChocolate;

namespace CashmereServer.GraphQL.Resolvers
{
    public class AccountResolver
    {
        public Task<User> GetUser(Account account, [DataLoader]UserDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(account.UserId);
        }
    }
}