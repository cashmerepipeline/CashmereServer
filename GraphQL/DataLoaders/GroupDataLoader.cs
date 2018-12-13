using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDonut;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.DataLoaders
{
    public class GroupDataLoader
        :DataLoaderBase<Guid, Group>
    {
        private readonly CashmereRepository _cashmereRepository;
        public GroupDataLoader(CashmereRepository cashmereRepository)
            :base(new DataLoaderOptions<Guid>())
        {
            _cashmereRepository = cashmereRepository;
        }

         public List<IReadOnlyList<Guid>> Loads { get; } =
            new List<IReadOnlyList<Guid>>();

        protected override Task<IReadOnlyList<IResult<Group>>> Fetch(
            IReadOnlyList<Guid> keys)
        {
            // The fetch method has to return a result for each key in the same order as the keys.
            // So if the repository returns less or in a different order this fetch method must return an Array
            // or list of values the same length as the Array of keys, and re-order them to ensure each
            // index aligns with the original keys.
            // https://github.com/facebook/dataloader -> Section Batching

            var result = _cashmereRepository.GetGroupByIds(keys).ToDictionary(t => t.Id);
            var list = new List<Result<Group>>();

            foreach (var key in keys)
            {
                if (result.TryGetValue(key, out Group group))
                {
                    list.Add(Result<Group>.Resolve(group));
                }
                else
                {
                    // if there was an exception during the resolve use Result<Group>.Reject(error);
                    list.Add(Result<Group>.Resolve(null));
                }
            }

            return System.Threading.Tasks.Task.FromResult<IReadOnlyList<IResult<Group>>>(list);
        }
    }
}