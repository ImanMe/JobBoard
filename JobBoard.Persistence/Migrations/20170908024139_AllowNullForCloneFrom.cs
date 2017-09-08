using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class AllowNullForCloneFrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EverGreenId",
                table: "Jobs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CloneFrom",
                table: "Jobs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EverGreenId",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CloneFrom",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
