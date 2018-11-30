using Microsoft.EntityFrameworkCore.Migrations;

namespace CashmereServer.Database.Migrations
{
    public partial class imixdbv002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Families",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SexType",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "User",
                newName: "GivenName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FamilyName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "User",
                newName: "NickName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FamilyName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Families",
                table: "User",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SexType",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }
    }
}
