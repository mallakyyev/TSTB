using Microsoft.EntityFrameworkCore.Migrations;

namespace TSTB.DAL.Migrations
{
    public partial class VideoLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Services",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Services");
        }
    }
}
