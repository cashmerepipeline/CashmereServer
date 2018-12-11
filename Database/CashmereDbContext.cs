
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
                if((model.GetField("Id") == null))
                    continue;

                _BaseEntityFieldsConfig(modelBuilder, model);
                // modelBuilder.Entity<Activator.CreateInstance(model)>()
            }

            modelBuilder.Entity<Account>().HasIndex(a=>a.Email).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a=>a.PhoneNumber).IsUnique();
            modelBuilder.Entity<Account>().Property(p=>p.AccountGroupIds).HasDefaultValue(null);
            modelBuilder.Entity<Account>().Property(p=>p.AccountTeamIds).HasDefaultValue(null);
            modelBuilder.Entity<Account>().Property(p=>p.IsHuman).HasDefaultValue(true);
           

            // modelBuilder.Entity<User>().Property(u=>u.)


            // account -- team many-many
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

            // account -- group many-many
            modelBuilder.Entity<AccountGroup>()
                .HasKey(at => new { at.AccountId, at.GroupId });
            modelBuilder.Entity<AccountGroup>()
                .HasOne(at=>at.Account)
                .WithMany(a=>a.AccountGroups)
                .HasForeignKey(at=>at.AccountId);
            modelBuilder.Entity<AccountGroup>()
                .HasOne(at=>at.Group)
                .WithMany(t=>t.AccountGroups)
                .HasForeignKey(t=>t.GroupId);
        }

       private ModelBuilder _BaseEntityFieldsConfig(ModelBuilder modelBuilder, Type modelType)
        {
            var newModelBuilder = modelBuilder.Entity(modelType);
            newModelBuilder
                        .Property("Id")
                        .ValueGeneratedOnAdd()
                        .UseNpgsqlIdentityColumn();
            
            // newModelBuilder
                        // .Property("Uuid")
                        // .ValueGeneratedOnAdd()
                        // .HasDefaultValueSql("uuid_generate_v4()");

            newModelBuilder.HasAlternateKey("Uuid");

            newModelBuilder
                        .Property("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("transaction_timestamp()");

            newModelBuilder
                        .Property("ModifiedTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("transaction_timestamp()")
                        .HasDefaultValueSql("transaction_timestamp()");
                        
            // newModelBuilder
                        // .Property("ExtendData")
                        // .HasColumnType("jsonb");

            return modelBuilder;
        }

        private IEnumerable<Type> _GetModelTypes()
        {
            string name_space = "CashmereServer.Database.Models";
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, name_space, StringComparison.Ordinal));
        }
    }
}