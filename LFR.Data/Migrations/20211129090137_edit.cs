using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LFR.Web.Data.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LawyerCharges_Contracts_ContractId",
                table: "LawyerCharges");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerCharges_Issues_IssueId",
                table: "LawyerCharges");

            migrationBuilder.DropIndex(
                name: "IX_LawyerCharges_ContractId",
                table: "LawyerCharges");

            migrationBuilder.DropIndex(
                name: "IX_LawyerCharges_IssueId",
                table: "LawyerCharges");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "LawyerCharges");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "LawyerCharges");

            migrationBuilder.DropColumn(
                name: "LawyerCharge",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LawyerChargeId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LawyerChargeId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_LawyerChargeId",
                table: "Issues",
                column: "LawyerChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_LawyerChargeId",
                table: "Contracts",
                column: "LawyerChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_LawyerCharges_LawyerChargeId",
                table: "Contracts",
                column: "LawyerChargeId",
                principalTable: "LawyerCharges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_LawyerCharges_LawyerChargeId",
                table: "Issues",
                column: "LawyerChargeId",
                principalTable: "LawyerCharges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_LawyerCharges_LawyerChargeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_LawyerCharges_LawyerChargeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_LawyerChargeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_LawyerChargeId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "LawyerChargeId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "LawyerChargeId",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "LawyerCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "LawyerCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LawyerCharge",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerCharges_ContractId",
                table: "LawyerCharges",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LawyerCharges_IssueId",
                table: "LawyerCharges",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerCharges_Contracts_ContractId",
                table: "LawyerCharges",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerCharges_Issues_IssueId",
                table: "LawyerCharges",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
