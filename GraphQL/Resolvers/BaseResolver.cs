using System.Threading.Tasks;
using System.Reflection;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.DataLoaders;
using HotChocolate;

namespace CashmereServer.GraphQL.Resolvers
{
    public class BaseResolver<TEntity> where TEntity : IBaseEntity
    {
        public Task<Account> GetCreator(TEntity entity, [DataLoader]AccountDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(entity.CreatorId);
        }

        public Task<Account> GetModifier(TEntity entity, [DataLoader]AccountDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(entity.ModifierId);
        }

    }
}