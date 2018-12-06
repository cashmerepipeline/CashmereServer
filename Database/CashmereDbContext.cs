
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CashmereServer.Database.Models;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace CashmereServer.Database
{
    public class CashmereDbContext : DbContext
    {
    
        public CashmereDbContext(DbContextOptions<CashmereDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts{get; set;}
        public DbSet<Group> Groups{get; set;}
        public DbSet<Team> Teams{get; set;}
        public DbSet<Role> Roles{get; set;}
        
        public DbSet<User> Users { get; set; }
        // public DbSet<BaseEntity> BaseEntity {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp"); 

            modelBuilder.Ignore<BaseEntity>();

            foreach (var model in _GetModelTypes())
            {
                //skip interface
                if (model.IsInterface)
                    continue;

                _BaseEntityFieldsConfig(modelBuilder, model);
                // modelBuilder.Entity<Activator.CreateInstance(model)>()
            }

            modelBuilder.Entity<AccountTeam>()
                .HasKey(at => new { at.AccountId, at.TeamId });

            modelBuilder.Entity<AccountTeam>()
                .HasOne(at=>at.Account)
                .WithMany(a=>a.AccountTeams)
                .HasForeignKey(at=>at.AccountId);

            modelBuilder.Entity<AccountTeam>()
                .HasOne(at=>at.Team)
                .WithMany(t=>t.AccountTeams)
                .HasForeignKey(t=>t.TeamId);
        }

       private ModelBuilder _BaseEntityFieldsConfig(ModelBuilder modelBuilder, Type modelType)
        {
            var newModelBuilder = modelBuilder.Entity(modelType);
            newModelBuilder
                        .Property("Id")
                        .ValueGeneratedOnAdd()
                        .UseNpgsqlIdentityColumn();

            newModelBuilder
                        .Property("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v4()");

            newModelBuilder
                        .Property("CreatingTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("transaction_timestamp()");

            newModelBuilder
                        .Property("ModifiedTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("transaction_timestamp()");
                        
            newModelBuilder
                        .Property("ExtendData")
                        .HasColumnType("jsonb");

            return modelBuilder;
        }

        private IEnumerable<Type> _GetModelTypes()
        {
            string name_space = "IMixServer.Database.Models";
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, name_space, StringComparison.Ordinal));
        }
    }
}