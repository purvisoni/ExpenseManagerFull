using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseManagerMVC.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseDetails",
                columns: table => new
                {
                    ExpenseDetailEFId = table.Column<Guid>(nullable: false),
                    StoreName = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetails", x => x.ExpenseDetailEFId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDetails");
        }
    }
}
