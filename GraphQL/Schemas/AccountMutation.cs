using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.Schemas
{
    public partial class Mutation
    {
        public Account NewAccount(string name, string phoneNumber, string email, string password)
        {
            var a = new Account();
            a.Name = name;
            a.PhoneNumber = phoneNumber;
            a.Email = email;
            a.Password = password;

            _repository.NewAccount(a);

            return a;
        }

        public Task<Account> UpdateAccount(Guid id, Dictionary<string, dynamic> properties)
        {
            return _repository.UpdateAccount(id, properties);
        }

        public User NewUser(string name)
        {
            User c = new User();
            c.Id = Guid.NewGuid();
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