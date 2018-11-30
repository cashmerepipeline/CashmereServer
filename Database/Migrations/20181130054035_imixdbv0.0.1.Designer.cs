﻿// <auto-generated />
using System;
using CashmereServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CashmereServer.Database.Migrations
{
    [DbContext(typeof(CashmereDbContext))]
    [Migration("20181130054035_imixdbv0.0.1")]
    partial class imixdbv001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CashmereServer.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("transaction_timestamp()");

                    b.Property<string>("Email");

                    b.Property<string>("ExtendData")
                        .HasColumnType("jsonb");

                    b.Property<string>("Families")
                        .HasColumnType("jsonb");

                    b.Property<string>("FamilyName");

                    b.Property<DateTime>("ModifyTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("transaction_timestamp()");

                    b.Property<string>("Name");

                    b.Property<string>("NickName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int>("SexType");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}