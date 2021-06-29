using Microsoft.EntityFrameworkCore.Migrations;

namespace TSTB.DAL.Migrations
{
    public partial class MembershipRequest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "MembershipRequests",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "MembershipRequests");
        }
    }
}
