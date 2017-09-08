using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "JobId",
                table: "Applicants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "JobBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstreamJbsId = table.Column<int>(type: "int", nullable: false),
                    IsEmailApply = table.Column<bool>(type: "bit", nullable: false),
                    IsOnlineApply = table.Column<bool>(type: "bit", nullable: false),
                    JobBoardName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OccupationCategory = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    OccupationName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    ApsCl = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bob = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CloneFrom = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Division = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailTo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: false),
                    EverGreenId = table.Column<long>(type: "bigint", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Intvs = table.Column<int>(type: "int", nullable: false),
                    Intvs2 = table.Column<int>(type: "int", nullable: false),
                    IsBestPerforming = table.Column<bool>(type: "bit", nullable: false),
                    IsEverGreen = table.Column<bool>(type: "bit", nullable: false),
                    IsOnlineApply = table.Column<bool>(type: "bit", nullable: false),
                    JobBoardId = table.Column<int>(type: "int", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    JobRequirements = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    MaximumExperience = table.Column<short>(type: "smallint", nullable: false),
                    MinimumExperience = table.Column<short>(type: "smallint", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SalaryTypeId = table.Column<int>(type: "int", nullable: false),
                    SchedulingPod = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_JobBoards_JobBoardId",
                        column: x => x.JobBoardId,
                        principalTable: "JobBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_SalaryTypes_SalaryTypeId",
                        column: x => x.SalaryTypeId,
                        principalTable: "SalaryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOccupations",
                columns: table => new
                {
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    OccupationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOccupations", x => new { x.JobId, x.OccupationId });
                    table.ForeignKey(
                        name: "FK_JobOccupations_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOccupations_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOccupations_OccupationId",
                table: "JobOccupations",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CountryId",
                table: "Jobs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmploymentTypeId",
                table: "Jobs",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobBoardId",
                table: "Jobs",
                column: "JobBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SalaryTypeId",
                table: "Jobs",
                column: "SalaryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOccupations");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "JobBoards");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Applicants");
        }
    }
}
