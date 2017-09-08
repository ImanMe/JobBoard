using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class OtherFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "MinimumExperience",
                table: "Jobs",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<short>(
                name: "MaximumExperience",
                table: "Jobs",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "MinimumExperience",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "MaximumExperience",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }
    }
}
