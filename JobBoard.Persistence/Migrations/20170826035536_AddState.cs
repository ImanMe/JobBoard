using Microsoft.EntityFrameworkCore.Migrations;

namespace JobBoard.Persistence.Migrations
{
    public partial class AddState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_StateId",
                table: "Jobs",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_States_StateId",
                table: "Jobs",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_States_StateId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_StateId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Jobs");
        }
    }
}
