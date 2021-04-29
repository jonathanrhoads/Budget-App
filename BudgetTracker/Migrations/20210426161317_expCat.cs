using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracker.Migrations
{
    public partial class expCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "MonthlyCosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_MonthlyCosts_CatId",
            //    table: "MonthlyCosts",
            //    column: "CatId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MonthlyCosts_ExpenseCategory_CatId",
            //    table: "MonthlyCosts",
            //    column: "CatId",
            //    principalTable: "ExpenseCategory",
            //    principalColumn: "CatID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_MonthlyCosts_ExpenseCategory_CatId",
            //    table: "MonthlyCosts");

            //migrationBuilder.DropIndex(
            //    name: "IX_MonthlyCosts_CatId",
            //    table: "MonthlyCosts");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "MonthlyCosts");
        }
    }
}
