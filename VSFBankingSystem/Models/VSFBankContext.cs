using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VSFBankingSystem.Models
{
    public partial class VSFBankContext : DbContext
    {
        public VSFBankContext()
        {
        }

        public VSFBankContext(DbContextOptions<VSFBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddPayee> AddPayees { get; set; } = null!;
        public virtual DbSet<Banking> Bankings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAcc> CustomerAccs { get; set; } = null!;
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; } = null!;
        public virtual DbSet<ValidLogin> ValidLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VSFBank;user id=Guestuser;password=vat@1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddPayee>(entity =>
            {
                entity.HasKey(e => e.BeneficiaryAccountNumber)
                    .HasName("PK__AddPayee__7BFF6B71B2E0816B");

                entity.ToTable("AddPayee");

                entity.Property(e => e.BeneficiaryAccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.AddPayees)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("fk_AccNum_AddPay");
            });

            modelBuilder.Entity<Banking>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.CustomerId })
                    .HasName("PK__Banking__24602B23CCE9DEBA");

                entity.ToTable("Banking");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.CustomerId).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Bankings)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccNum");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.AadharNumber).HasColumnType("numeric(16, 0)");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EnableNetBanking)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FathersName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAnnualIncome).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.IsDebitCardRequired)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("isDebitCardRequired");

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.OccupationType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOfIncome)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAcc>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Customer__BE2ACD6E0F281AB9");

                entity.ToTable("CustomerAcc");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.CustomerId).HasColumnType("numeric(12, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAccs)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_cust_ID");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Transact__55433A6BE5E77E31");

                entity.ToTable("TransactionDetail");

                entity.Property(e => e.TransactionId).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Maturityinstruct)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.TransType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("fk_AccNum_Tr");
            });

            modelBuilder.Entity<ValidLogin>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__ValidLog__A4AE64D8DFC3020B");

                entity.ToTable("ValidLogin");

                entity.Property(e => e.CustomerId).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.ValidLogin)
                    .HasForeignKey<ValidLogin>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Custid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
