using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {

        public Task<Team> GetTeam(Guid id)
        {
            return _dbContext.Teams.FindAsync(id);
        }

        public IEnumerable<Team> GetTeamByIds(IEnumerable<Guid> ids)
        {
            return _dbContext.Teams.ToList().Where(a => ids.Contains(a.Id));
        }

        public int NewTeam(Team Team)
        {
            _dbContext.Teams.Add(Team);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<Team> UpdateTeam(Guid id, string name)
        {
            var c = _dbContext.Teams.FindAsync(id).Result;
            c.Name = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}