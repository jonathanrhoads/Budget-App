using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracker.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MonthlyCosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MonthlyCosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCosts_ApplicationUserId",
                table: "MonthlyCosts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyCosts_AspNetUsers_ApplicationUserId",
                table: "MonthlyCosts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyCosts_AspNetUsers_ApplicationUserId",
                table: "MonthlyCosts");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyCosts_ApplicationUserId",
                table: "MonthlyCosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MonthlyCosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MonthlyCosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");
        }
    }
}
