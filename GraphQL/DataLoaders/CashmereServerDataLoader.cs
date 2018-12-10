
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;
using GreenDonut;

namespace CashmereServer.GraphQL.DataLoaders
{
    public class AccountDataLoader : DataLoaderBase<Guid, Account>
    {
        private readonly CashmereRepository _repository;
        public AccountDataLoader(CashmereRepository repository)
            : base(new DataLoaderOptions<Guid>())
        {
            _repository = repository;
        }


        protected override IAsyncEnumerable<Account> Fetch(IReadOnlyList<Guid> keys)
        {
            return _repository.GetAccountByIds(keys);
        }
    }
}