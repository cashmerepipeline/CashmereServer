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
        :DataLoaderBase<string, Account>
    {
        private readonly CashmereRepository _cashmereRepository;
        public AccountDataLoader(CashmereRepository cashmereRepository)
            :base(new DataLoaderOptions<string>())
        {
            _cashmereRepository = cashmereRepository;
        }

         public List<IReadOnlyList<string>> Loads { get; } =
            new List<IReadOnlyList<string>>();

        protected override Task<IReadOnlyList<IResult<Account>>> Fetch(
            IReadOnlyList<string> keys)
        {
            // The fetch method has to return a result for each key in the same order as the keys.
            // So if the repository returns less or in a different order this fetch method must return an Array
            // or list of values the same length as the Array of keys, and re-order them to ensure each
            // index aligns with the original keys.
            // https://github.com/facebook/dataloader -> Section Batching

            var result = _cashmereRepository.GetAccountByIds(keys).ToDictionary(t => t.Id);
            var list = new List<Result<Account>>();

            foreach (string key in keys)
            {
                if (result.TryGetValue(key, out Account account))
                {
                    list.Add(Result<Account>.Resolve(account));
                }
                else
                {
                    // if there was an exception during the resolve use Result<Account>.Reject(error);
                    list.Add(Result<Account>.Resolve(null));
                }
            }

            return System.Threading.Tasks.Task.FromResult<IReadOnlyList<IResult<Account>>>(list);
        }
    }
}