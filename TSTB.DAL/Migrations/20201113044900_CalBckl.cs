using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TSTB.DAL.Migrations
{
    public partial class CalBckl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CallBacks");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OnlineTradings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "CallBackTranslate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CallBackId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallBackTranslate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallBackTranslate_CallBacks_CallBackId",
                        column: x => x.CallBackId,
                        principalTable: "CallBacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallBackTranslate_CallBackId",
                table: "CallBackTranslate",
                column: "CallBackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallBackTranslate");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OnlineTradings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CallBacks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
