using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CashmereServer.Database.Migrations
{
    public partial class imixdbv001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uuid = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValueSql: "transaction_timestamp()"),
                    ModifyTime = table.Column<DateTime>(nullable: false, defaultValueSql: "transaction_timestamp()"),
                    ExtendData = table.Column<string>(type: "jsonb", nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    SexType = table.Column<int>(nullable: false),
                    FamilyName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Families = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
