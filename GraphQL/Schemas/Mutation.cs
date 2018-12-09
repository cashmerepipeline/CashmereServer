using System;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.Schemas
{
    public class Mutation
    {
        private readonly CashmereRepository _repository;

        public Mutation(CashmereRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }
        public User NewUser(string name){
            User c = new User();
            c.Id=new Guid();
            c.GivenName = name;
            _repository.NewUserAsync(c);
            return c;
        }

        public User UpdateUser(int id, string name)
        {
            var c = _repository.UpdateUser(id, name);
            
            return c.Result;
        }
    }
}