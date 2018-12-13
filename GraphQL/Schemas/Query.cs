using System;
using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;
using CashmereServer.GraphQL.DataLoaders;
using HotChocolate;

namespace CashmereServer.GraphQL.Schemas
{
    public class Query
    {
        private readonly CashmereRepository _repository;

        public Query(CashmereRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }
        // public string Hello() => "world";
        
        public Task<Account> GetAccount(Guid id)
        {
            return _repository.GetAccount(id);
        }

        public Task<Account> GetAccount(Guid id, [DataLoader]AccountDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(id);
        }

        public Group GetGroup(Guid id)
        {
            return _repository.GetGroup(id).Result;
        }

        public Task<Group> GetGroup(Guid id, [DataLoader]GroupDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(id);
        }

        public Team GetTeam(Guid id)
        {
            return _repository.GetTeam(id).Result;
        }

        public Task<Team> GetTeam(Guid id, [DataLoader]TeamDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(id);
        }

        public User GetUser(Guid id)
        {
            return _repository.GetUser(id).Result;
        }

        public Task<User> GetUser(Guid id, [DataLoader]UserDataLoader dataLoader)
        {
            return dataLoader.LoadAsync(id);
        }
    }
}
