using System;
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

        public BudgetContext(DbContextOptions<BudgetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<MonthlyCost> MonthlyCosts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Subcat> Subcats { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

                entity.Property(e => e.ActualCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Difference).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProjectedCost).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.SubcatId).HasColumnName("SubcatID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Subcat)
                    .WithMany()
                    .HasForeignKey(d => d.SubcatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcats_MonthlyCosts_SubcatID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Users_MonthlyCosts_UserID");
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

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpenseCategory_Purchases_CatID");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.PaymentMethodId);
            });

            modelBuilder.Entity<Subcat>(entity =>
            {
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserIncome1).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.UserIncome2).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
