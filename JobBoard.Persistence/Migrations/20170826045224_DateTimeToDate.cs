using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class DateTimeToDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Jobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditedDate",
                table: "Jobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Jobs",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Jobs",
                type: "date",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                table: "Jobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Applicants",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditedDate",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Jobs",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Jobs",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "date",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Applicants",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
