using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.Models
{
    public class Expenses
    {
        [Key]
        public int ExpenseId { get; set; }
        public string UserId { get; set; }
        [DisplayName("Mortgage/Rent")]
        public decimal MortgageRent { get; set; }
        public decimal Phone { get; set; }
        public decimal Gas { get; set; }
        [DisplayName("Water/Sewer/Trash")]
        public decimal WaterSewerTrash { get; set; }
        public decimal Electricity { get; set; }
        [DisplayName("Cable/Internet")]
        public decimal CableInternet { get; set; }
        [DisplayName("Home Alarm System")]
        public decimal HomeAlarmSystem { get; set; }
        [DisplayName("Maintenence/Repairs")]
        public decimal MaintenanceRepairs { get; set; }
        [DisplayName("Vehicle Payment")]
        public decimal VehiclePayment { get; set; }
        public decimal Insurance { get; set; }
        public decimal Fuel { get; set; }
        [DisplayName("Uber/Lyft")]
        public decimal UberLyft { get; set; }
        [DisplayName("Licence/Registration")]
        public decimal LicenseRegistration { get; set; }
        public decimal Maintenance { get; set; }
        [DisplayName("Home/Renters")]
        public decimal HomeRenters { get; set; }
        public decimal Health { get; set; }
        public decimal Dental { get; set; }
        public decimal Vision { get; set; }
        public decimal Pet { get; set; }
        public decimal Life { get; set; }
        public decimal Groceries { get; set; }
        [DisplayName("Dining Out")]
        public decimal DiningOut { get; set; }
        public decimal Coffee { get; set; }
        [DisplayName("Clothes/Shoes")]
        public decimal ClothesShoes { get; set; }
        [DisplayName("School/Tuition/Supplies")]
        public decimal SchoolTuitionSupplies { get; set; }
        [DisplayName("Sports Organization Fees")]
        public decimal SportsOrganizationFees { get; set; }
        public decimal Childcare { get; set; }
        [DisplayName("Lunch Money")]
        public decimal LunchMoney { get; set; }
        [DisplayName("Toys/Games")]
        public decimal ToysGames { get; set; }
        [DisplayName("Hair Cuts/Salon")]
        public decimal HairCutsSalon { get; set; }
        [DisplayName("Mani/Pedi/Waxing")]
        public decimal ManiPediWaxing { get; set; }
        [DisplayName("Clothes/Shoes/Accessories")]
        public decimal ClothesShoesAccessories { get; set; }
        [DisplayName("Dry Cleaning")]
        public decimal DryCleaning { get; set; }
        [DisplayName("Gym Supplements")]
        public decimal GymSupplements { get; set; }
        [DisplayName("Organization Dues/Fees")]
        public decimal OrganizationDuesFees { get; set; }
        public decimal Music { get; set; }
        public decimal Video { get; set; }
        [DisplayName("Movie Theater")]
        public decimal MovieTheater { get; set; }
        public decimal Concerts { get; set; }
        [DisplayName("Sporting Events")]
        public decimal SportingEvents { get; set; }
        [DisplayName("Date Nights")]
        public decimal DateNights { get; set; }
        public decimal Alchohol { get; set; }
        [DisplayName("Tobacco/Vaping")]
        public decimal TobaccoVaping { get; set; }
        [DisplayName("Personal Loans")]
        public decimal PersonalLoan { get; set; }
        [DisplayName("Credit Card")]
        public decimal CreditCard { get; set; }
        [DisplayName("Student Loan")]
        public decimal StudentLoan { get; set; }
        public decimal Federal { get; set; }
        public decimal State { get; set; }
        public decimal Medicare { get; set; }
        [DisplayName("Social Security/FICA")]
        public decimal SocialSecurityFICA { get; set; }
        [DisplayName("Emergency Savings")]
        public decimal EmergencySavings { get; set; }
        [DisplayName("CDs/Money Markets")]
        public decimal CDsMoneyMarkets { get; set; }
        [DisplayName("401k/IRA")]
        public decimal IRA401k { get; set; }
        [DisplayName("Stocks/Mutual Funds")]
        public decimal StocksMutualFunds { get; set; }
        [DisplayName("Tithes/Offerings")]
        public decimal Tithesffering { get; set; }
        public decimal Charity { get; set; }
        [DisplayName("Retirement Home")]
        public decimal RetirementHome { get; set; }
        public decimal Attorney { get; set; }
        [DisplayName("Alimoney/Child Support")]
        public decimal AlimonyChildSupport { get; set; }
        [DisplayName("Lien/Judgement Payment")]
        public decimal LienJudgmentPayment { get; set; }
        [DisplayName("Monthly Income")]
        public decimal MonthlyIncome { get; set; }
        [DisplayName("Total Cost")]
        public decimal TotalCost { get; set; }
        [DisplayName("Income vs Total")]
        public decimal IncomeVsTotal { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public decimal GetTotalCost =>
            MortgageRent + Phone + Gas + WaterSewerTrash + Electricity + CableInternet +
            HomeAlarmSystem + MaintenanceRepairs + VehiclePayment + Insurance +
            Fuel + UberLyft + LicenseRegistration + Maintenance +
            HomeRenters + Health + Dental + Vision + Pet + Life + Groceries + DiningOut +
            Coffee + ClothesShoes + SchoolTuitionSupplies + SportsOrganizationFees + Childcare +
            LunchMoney + ToysGames + HairCutsSalon + ManiPediWaxing + ClothesShoesAccessories +
            DryCleaning + GymSupplements + OrganizationDuesFees + Music + Video + MovieTheater +
            Concerts + SportingEvents + DateNights + Alchohol + TobaccoVaping + PersonalLoan + CreditCard +
            StudentLoan + Federal + State + Medicare + SocialSecurityFICA + EmergencySavings + CDsMoneyMarkets +
            IRA401k + StocksMutualFunds + Tithesffering + Charity + RetirementHome + Attorney +
            AlimonyChildSupport + LienJudgmentPayment;

        public decimal GetIncomeVsTotal => MonthlyIncome - TotalCost;
    }
}
