using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDonut;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.DataLoaders
{
    public class AccountDataLoader
        : DataLoaderBase<Guid, Account>
    {
        private readonly CashmereRepository _cashmereRepository;
        public AccountDataLoader(CashmereRepository cashmereRepository)
            : base(new DataLoaderOptions<Guid>())
        {
            _cashmereRepository = cashmereRepository;
        }

        public List<IReadOnlyList<Guid>> Loads { get; } =
           new List<IReadOnlyList<Guid>>();

        protected override Task<IReadOnlyList<IResult<Account>>> Fetch(
            IReadOnlyList<Guid> keys)
        {
            var result = _cashmereRepository.GetAccountByIds(keys).ToDictionary(t => t.Id);
            var list = new List<Result<Account>>();

            foreach (var key in keys)
            {
                if (result.TryGetValue(key, out Account account))
                {
                    list.Add(Result<Account>.Resolve(account));
                }
                else
                {
                    list.Add(Result<Account>.Resolve(null));
                }
            }

            return System.Threading.Tasks.Task.FromResult<IReadOnlyList<IResult<Account>>>(list);
        }
    }
}