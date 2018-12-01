
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CashmereServer.Database.Models;
using NodaTime;
using System;

namespace CashmereServer.Database
{
    public class CashmereDbContext : DbContext
    {
    
        public CashmereDbContext(DbContextOptions<CashmereDbContext> options)
            : base(options) { }

        public DbSet<User> User { get; set; }
        // public DbSet<BaseEntity> BaseEntity {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp"); 

            _BaseEntityFieldsConfig<User>(modelBuilder);
        }

        private ModelBuilder _BaseEntityFieldsConfig<TEntity>(ModelBuilder modelBuilder) 
            where TEntity : class, IBaseEntity
        {
            modelBuilder.Entity<TEntity>()
                        .Property(e=>e.Id)
                        .ValueGeneratedOnAdd()
                        .UseNpgsqlIdentityColumn();
            modelBuilder.Entity<TEntity>()
                        .Property(e=>e.Uuid)
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<TEntity>()
                        .Property(e=>e.CreationTime)
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("transaction_timestamp()");
            modelBuilder.Entity<TEntity>()
                        .Property(e=>e.ModifiedTime)
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("transaction_timestamp()");
            modelBuilder.Entity<TEntity>()
                        .Property(e=>e.ExtendData)
                        .HasColumnType("jsonb");

            return modelBuilder;
        } 
    }
}