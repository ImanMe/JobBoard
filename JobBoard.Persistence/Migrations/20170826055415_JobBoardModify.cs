using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobBoard.Persistence.Migrations
{
    public partial class JobBoardModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstreamJbsId",
                table: "JobBoards",
                newName: "EstreamJBsID ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstreamJBsID ",
                table: "JobBoards",
                newName: "EstreamJbsId");
        }
    }
}
