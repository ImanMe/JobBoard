using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class SeperateStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApsCl",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Bob",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Intvs",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Intvs2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsOnlineApply",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApsCl = table.Column<int>(type: "int", nullable: true),
                    Bob = table.Column<int>(type: "int", nullable: true),
                    Intvs = table.Column<int>(type: "int", nullable: true),
                    Intvs2 = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_JobId",
                table: "Stats",
                column: "JobId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.AddColumn<int>(
                name: "ApsCl",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bob",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intvs",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intvs2",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnlineApply",
                table: "Jobs",
                nullable: false,
                defaultValue: false);
        }
    }
}
