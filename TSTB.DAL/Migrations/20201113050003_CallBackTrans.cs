using Microsoft.EntityFrameworkCore.Migrations;

namespace TSTB.DAL.Migrations
{
    public partial class CallBackTrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallBackTranslate_CallBacks_CallBackId",
                table: "CallBackTranslate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallBackTranslate",
                table: "CallBackTranslate");

            migrationBuilder.RenameTable(
                name: "CallBackTranslate",
                newName: "CallBackTranslates");

            migrationBuilder.RenameIndex(
                name: "IX_CallBackTranslate_CallBackId",
                table: "CallBackTranslates",
                newName: "IX_CallBackTranslates_CallBackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallBackTranslates",
                table: "CallBackTranslates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallBackTranslates_CallBacks_CallBackId",
                table: "CallBackTranslates",
                column: "CallBackId",
                principalTable: "CallBacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallBackTranslates_CallBacks_CallBackId",
                table: "CallBackTranslates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallBackTranslates",
                table: "CallBackTranslates");

            migrationBuilder.RenameTable(
                name: "CallBackTranslates",
                newName: "CallBackTranslate");

            migrationBuilder.RenameIndex(
                name: "IX_CallBackTranslates_CallBackId",
                table: "CallBackTranslate",
                newName: "IX_CallBackTranslate_CallBackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallBackTranslate",
                table: "CallBackTranslate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallBackTranslate_CallBacks_CallBackId",
                table: "CallBackTranslate",
                column: "CallBackId",
                principalTable: "CallBacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
