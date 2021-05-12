using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracker.Migrations
{
    public partial class Expense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    MortgageRent = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Phone = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Gas = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    WaterSewerTrash = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Electricity = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CableInternet = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    HomeAlarmSystem = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MaintenanceRepairs = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    VehiclePayment = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Insurance = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Fuel = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    UberLyft = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    LicenseRegistration = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Maintenance = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    HomeRenters = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Health = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Dental = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Vision = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Pet = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Life = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Groceries = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    DiningOut = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Coffee = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ClothesShoes = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    SchoolTuitionSupplies = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    SportsOrganizationFees = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Childcare = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    LunchMoney = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ToysGames = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    HairCutsSalon = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ManiPediWaxing = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ClothesShoesAccessories = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    DryCleaning = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    GymSupplements = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    OrganizationDuesFees = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Music = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Video = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MovieTheater = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Concerts = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    SportingEvents = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    DateNights = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Alchohol = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TobaccoVaping = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    PersonalLoan = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CreditCard = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    StudentLoan = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Federal = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    State = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Medicare = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    SocialSecurityFICA = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    EmergencySavings = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CDsMoneyMarkets = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IRA401k = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    StocksMutualFunds = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Tithesffering = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Charity = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    RetirementHome = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Attorney = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    AlimonyChildSupport = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    LienJudgmentPayment = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IncomeVsTotal = table.Column<decimal>(type: "decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expenses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
