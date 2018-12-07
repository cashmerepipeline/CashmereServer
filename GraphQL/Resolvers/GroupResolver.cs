using System.Collections.Generic;
using System.Threading.Tasks;
using CashmereServer.Database.Models;
using CashmereServer.GraphQL.Repositories;
using HotChocolate;
using CashmereServer.Database.Models;

namespace CashmereServer.GraphQL.Resolvers
{
    public class GroupResolver
    {
        private readonly CashmereRepository repository;

        public Task<IEnumerable<Group>> GetGroups(int[] ids, [Service]CashmereRepository repository)
        {

            return Task(repository.GetGroupsAsync(ids));
        }
    }
}