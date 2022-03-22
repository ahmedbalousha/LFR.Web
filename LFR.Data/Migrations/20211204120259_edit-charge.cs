using Microsoft.EntityFrameworkCore.Migrations;

namespace LFR.Web.Data.Migrations
{
    public partial class editcharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Residual",
                table: "LawyerCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Residual",
                table: "LawyerCharges");
        }
    }
}
