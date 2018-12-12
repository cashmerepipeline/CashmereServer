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

        public Account NewAccount(string name, string phoneNumber, string email, string password)
        {
            var a = new Account();
            a.Name = name;
            a.PhoneNumber = phoneNumber;
            a.Email = email;
            a.Password = password;

            _repository.NewAccountAsync(a);
            
            return a;
        }

        public User NewUser(string name){
            User c = new User();
            c.Id=new Guid().ToString();
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