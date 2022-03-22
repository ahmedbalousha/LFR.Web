using Microsoft.EntityFrameworkCore.Migrations;

namespace LFR.Web.Data.Migrations
{
    public partial class edits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_ContractClientId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractClientId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractClientId",
                table: "Contracts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractClientId",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractClientId",
                table: "Contracts",
                column: "ContractClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_ContractClientId",
                table: "Contracts",
                column: "ContractClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
