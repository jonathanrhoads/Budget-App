using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracker.Migrations
{
    public partial class AddUserIncomesToApplicationUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MonthlyCosts_UserID",
                table: "MonthlyCosts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyCosts_UserID",
                table: "MonthlyCosts");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "MonthlyCosts");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UserIncome1",
                table: "AspNetUsers",
                type: "decimal(19,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UserIncome2",
                table: "AspNetUsers",
                type: "decimal(19,4)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserIncome1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserIncome2",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "MonthlyCosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIncome1 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UserIncome2 = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCosts_UserID",
                table: "MonthlyCosts",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MonthlyCosts_UserID",
                table: "MonthlyCosts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
