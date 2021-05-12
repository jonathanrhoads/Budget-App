using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BudgetTracker.Models
{
    public partial class BudgetContext : IdentityDbContext
    {
        public BudgetContext()
        {
        }

        private readonly IHttpContextAccessor _httpContextAccessor;
        public BudgetContext(DbContextOptions<BudgetContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<MonthlyCost> MonthlyCosts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Subcat> Subcats { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers {get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-N4R8TO4\\MSSQLSERVER01;Initial Catalog=Budget;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);
                entity.ToTable("Expenses");

                entity.HasIndex(e => e.UserId, "IX_Expenses_ApplicationUserId");
        
        
                entity.Property(e => e.MortgageRent).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Phone).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Gas).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.WaterSewerTrash).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Electricity).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.CableInternet).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.HomeAlarmSystem).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.MaintenanceRepairs).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.VehiclePayment).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Insurance).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Fuel).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.UberLyft).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.LicenseRegistration).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Maintenance).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.HomeRenters).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Health).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Dental).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Vision).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Pet).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Life).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Groceries).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.DiningOut).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Coffee).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.ClothesShoes).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.SchoolTuitionSupplies).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.SportsOrganizationFees).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Childcare).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.LunchMoney).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.ToysGames).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.HairCutsSalon).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.ManiPediWaxing).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.ClothesShoesAccessories).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.DryCleaning).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.GymSupplements).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.OrganizationDuesFees).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Music).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Video).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.MovieTheater).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Concerts).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.SportingEvents).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.DateNights).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Alchohol).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.TobaccoVaping).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.PersonalLoan).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.CreditCard).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.StudentLoan).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Federal).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.State).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Medicare).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.SocialSecurityFICA).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.EmergencySavings).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.CDsMoneyMarkets).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.IRA401k).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.StocksMutualFunds).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Tithesffering).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Charity).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.RetirementHome).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.Attorney).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.AlimonyChildSupport).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.LienJudgmentPayment).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.MonthlyIncome).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.TotalCost).HasColumnType("decimal(19, 4)");
                entity.Property(e => e.IncomeVsTotal).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);

                

            });



            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.Property(e => e.RoleId).IsRequired();

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Discriminator)
            //        .IsRequired()
            //        .HasDefaultValueSql("(N'')");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserIncome1).HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.UserIncome2).HasColumnType("decimal(19, 4)");

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});



            // -----------------------------------------------------------

            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("ExpenseCategory");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MonthlyCost>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.UserId, "IX_MonthlyCosts_ApplicationUserId");

                entity.HasIndex(e => e.SubcatId, "IX_MonthlyCosts_SubcatID");

                entity.Property(e => e.ActualCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Difference).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProjectedCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.SubcatId).HasColumnName("SubcatID");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.Subcat)
                    .WithMany()
                    .HasForeignKey(d => d.SubcatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcats_MonthlyCosts_SubcatID");

                //entity.HasOne(d => d.User)
                //    .WithMany()
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK_MonthlyCosts_AspNetUsers");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.PaymentMethodName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasIndex(e => e.CatId, "IX_Purchases_CatID");

                entity.HasIndex(e => e.PaymentMethodId, "IX_Purchases_PaymentMethodID");

                entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PurchaseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpenseCategory_Purchases_CatID");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.PaymentMethodId);

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.Purchases)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK_Purchases_AspNetUsers");
            });

            modelBuilder.Entity<Subcat>(entity =>
            {
                entity.HasIndex(e => e.CatId, "IX_Subcats_CatID");

                entity.Property(e => e.SubcatId).HasColumnName("SubcatID");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.SubcatName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Subcats)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpenseCategory_Subcats_CatID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
