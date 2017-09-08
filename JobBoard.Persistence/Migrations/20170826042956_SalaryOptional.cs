using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class SalaryOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
