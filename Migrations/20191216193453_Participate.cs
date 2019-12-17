using Microsoft.EntityFrameworkCore.Migrations;

namespace CBelt.Migrations
{
    public partial class Participate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participate_Activs_ActivId",
                table: "Participate");

            migrationBuilder.DropForeignKey(
                name: "FK_Participate_Users_UserId",
                table: "Participate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participate",
                table: "Participate");

            migrationBuilder.RenameTable(
                name: "Participate",
                newName: "Participates");

            migrationBuilder.RenameColumn(
                name: "ActivId",
                table: "Participates",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Participate_UserId",
                table: "Participates",
                newName: "IX_Participates_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participate_ActivId",
                table: "Participates",
                newName: "IX_Participates_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participates",
                table: "Participates",
                column: "ParticipateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participates_Activs_ActivityId",
                table: "Participates",
                column: "ActivityId",
                principalTable: "Activs",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participates_Users_UserId",
                table: "Participates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participates_Activs_ActivityId",
                table: "Participates");

            migrationBuilder.DropForeignKey(
                name: "FK_Participates_Users_UserId",
                table: "Participates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participates",
                table: "Participates");

            migrationBuilder.RenameTable(
                name: "Participates",
                newName: "Participate");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Participate",
                newName: "ActivId");

            migrationBuilder.RenameIndex(
                name: "IX_Participates_UserId",
                table: "Participate",
                newName: "IX_Participate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participates_ActivityId",
                table: "Participate",
                newName: "IX_Participate_ActivId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participate",
                table: "Participate",
                column: "ParticipateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participate_Activs_ActivId",
                table: "Participate",
                column: "ActivId",
                principalTable: "Activs",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participate_Users_UserId",
                table: "Participate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
