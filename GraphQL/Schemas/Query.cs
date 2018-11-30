using System;
using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.Schemas
{
    public class Query
    {
        private readonly CashmerRepository _repository;

        public Query(CashmerRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }
        // public string Hello() => "world";

        public User GetUser(int id)
        {
            return _repository.GetUserAsync(id).Result;
        }
    }
}
