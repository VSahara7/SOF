using Microsoft.EntityFrameworkCore.Migrations;

namespace SHABAEIKO_ORGANIC_FARM.Migrations
{
    public partial class adduserstdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Users",
                newName: "Id");
        }
    }
}
