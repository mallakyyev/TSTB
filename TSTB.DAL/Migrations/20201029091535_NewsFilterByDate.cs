using Microsoft.EntityFrameworkCore.Migrations;

namespace TSTB.DAL.Migrations
{
    public partial class NewsFilterByDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TradingHouses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TradingHouses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TradingHouses");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TradingHouses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
