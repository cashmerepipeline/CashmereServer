using System;
using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

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

        public Account GetAccount(int id)
        {
            return _repository.GetAccountAsync(id).Result;
        }

        public Group GetGroup(int id)
        {
            return _repository.GetGroupAsync(id).Result;
        }

        public Team GetTeam(int id)
        {
            return _repository.GetTeamAsync(id).Result;
        }

        public User GetUser(int id)
        {
            return _repository.GetUserAsync(id).Result;
        }
    }
}
