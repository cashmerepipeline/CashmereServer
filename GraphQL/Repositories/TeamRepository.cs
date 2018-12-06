using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmerRepository
    {

        public Task<Team> GetTeamAsync(int id)
        {
            return _dbContext.Teams.FindAsync(id);
        }

        public Team GetTeam(int id)
        {
            return _dbContext.Teams.FindAsync(id).Result;
        }

        public int NewTeamAsync(Team Team)
        {
            _dbContext.Teams.Add(Team);
            var result = _dbContext.SaveChanges();
            return result;
        }

        internal async Task<Team> UpdateTeam(int id, string name)
        {
            var c = _dbContext.Teams.FindAsync(id).Result;
            c.Name = name;
            await _dbContext.SaveChangesAsync();
            return c;
        }
    }
}