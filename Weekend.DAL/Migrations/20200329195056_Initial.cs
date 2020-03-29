using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weekend.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<string>(maxLength: 50, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "(N'None')"),
                    Relationship = table.Column<string>(maxLength: 50, nullable: true),
                    Avatar = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginForm",
                columns: table => new
                {
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginForm", x => x.Login);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserLoginForm");
        }
    }
}
