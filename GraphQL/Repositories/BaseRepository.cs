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
        public CashmereRepository(CashmereDbContext db)
        {
            _dbContext = db;
        }

        // public static  Task<TEntity> GetEntityById<TEntity>(Guid id)
        // {
        //     return  _dbContext.FindAsync<TEntity>(id);
        // }

        // // public static  Task<TEntity> GetEntityByUuid<TEntity>(string uuid, CashmereDbContext dbContext) where TEntity: class
        // // {   
        // //     int id = dbContext.FindAsync
        // //     return  dbContext.FindAsync<TEntity>(uuid);
        // // }

        // public static Task<TEntity> GetEntityByIds<TEntity>(Guid[] ids)
        // {
        //     return  _dbContext.FindAsync<TEntity>(ids);
        // }
    }
}