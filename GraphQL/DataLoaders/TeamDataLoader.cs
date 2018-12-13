using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDonut;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;

namespace CashmereServer.GraphQL.DataLoaders
{
    public class TeamDataLoader
        : DataLoaderBase<Guid, Team>
    {
        private readonly CashmereRepository _cashmereRepository;
        public TeamDataLoader(CashmereRepository cashmereRepository)
            : base(new DataLoaderOptions<Guid>())
        {
            _cashmereRepository = cashmereRepository;
        }

        public List<IReadOnlyList<Guid>> Loads { get; } =
           new List<IReadOnlyList<Guid>>();

        protected override Task<IReadOnlyList<IResult<Team>>> Fetch(
            IReadOnlyList<Guid> keys)
        {
            var result = _cashmereRepository.GetTeamByIds(keys).ToDictionary(t => t.Id);
            var list = new List<Result<Team>>();

            foreach (var key in keys)
            {
                if (result.TryGetValue(key, out Team team))
                {
                    list.Add(Result<Team>.Resolve(team));
                }
                else
                {
                    // if there was an exception during the resolve use Result<Team>.Reject(error);
                    list.Add(Result<Team>.Resolve(null));
                }
            }

            return System.Threading.Tasks.Task.FromResult<IReadOnlyList<IResult<Team>>>(list);
        }
    }
}