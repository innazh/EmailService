using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace emailWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Body = table.Column<string>(maxLength: 10000, nullable: false),
                    Recipients = table.Column<string>(maxLength: 1000, nullable: false),
                    Created = table.Column<DateTime>(type: "Date", nullable: false),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");
        }
    }
}
