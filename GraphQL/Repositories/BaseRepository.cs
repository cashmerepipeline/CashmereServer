using System.Threading.Tasks;
using System.Linq;
using CashmereServer.Database;
using CashmereServer.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace CashmereServer.GraphQL.Repositories
{

    public partial class CashmereRepository
    {
        private readonly CashmereDbContext _dbContext;
        public CashmereRepository(CashmereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static  Task<TEntity> GetEntityById<TEntity>(int id, CashmereDbContext dbContext) where TEntity: class
        {
            return  dbContext.FindAsync<TEntity>(id);
        }

        public static Task<TEntity> GetEntityByIds<TEntity>(int[] ids, CashmereDbContext dbContext) where TEntity: class
        {
            return  dbContext.FindAsync<TEntity>(ids);
        }
    }
}