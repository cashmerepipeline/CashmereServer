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
        private readonly CashmereDbContext _dbContext;
        public CashmerRepository(CashmereDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}