using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BankingEFImpl.Models
{
    public partial class db_bankingContext : DbContext
    {
        public db_bankingContext()
        {
        }

        public db_bankingContext(DbContextOptions<db_bankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CorporateAccount> CorporateAccounts { get; set; }
        public virtual DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<SavingsAccount> SavingsAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AKSHYA-BL\\SQLEXPRESS;Initial Catalog=db_banking;Integrated Security=True");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__account__17D0878B05D2B7E6");

                entity.ToTable("account");

                entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("accountType");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerId");

                entity.Property(e => e.Doc)
                    .HasColumnType("date")
                    .HasColumnName("DOC");

                entity.Property(e => e.Ifsc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Tin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIN");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__account__custome__1ED998B2");
            });

            modelBuilder.Entity<CorporateAccount>(entity =>
            {
                entity.HasKey(e => e.CorporateAccountNo)
                    .HasName("PK_CorporateTable");

                entity.ToTable("corporateAccount");

                entity.Property(e => e.CorporateAccountNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("corporateAccountNo")
                    .HasDefaultValueSql("(format(NEXT VALUE FOR [CorporateSequence],'CO-000000#'))");

                entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");

                entity.Property(e => e.MinimumBalance).HasColumnName("minimumBalance");

                entity.Property(e => e.WithdrawlLimit).HasColumnName("withdrawlLimit");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.CorporateAccounts)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__corporate__accou__2D27B809");
            });

            modelBuilder.Entity<CurrentAccount>(entity =>
            {
                entity.HasKey(e => e.CurrentAccountNo)
                    .HasName("PK_CurrentTable");

                entity.ToTable("currentAccount");

                entity.Property(e => e.CurrentAccountNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("currentAccountNo")
                    .HasDefaultValueSql("(format(NEXT VALUE FOR [CurrentSequence],'CA-000000#'))");

                entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");

                entity.Property(e => e.MinimumBalance).HasColumnName("minimumBalance");

                entity.Property(e => e.WithdrawlLimit).HasColumnName("withdrawlLimit");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.CurrentAccounts)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__currentAc__accou__286302EC");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerId")
                    .HasDefaultValueSql("(format(NEXT VALUE FOR [CustomerSequence],'C-000000#'))");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("emailId");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("lastName");

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("managerId");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("mobileNumber");

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pincode");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__customer__manage__1BFD2C07");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("manager");

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("managerId")
                    .HasDefaultValueSql("(format(NEXT VALUE FOR [ManagerSequence],'M-000000#'))");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .HasColumnName("emailId");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("lastName");

                entity.Property(e => e.ManagerPassword)
                    .HasMaxLength(60)
                    .HasColumnName("managerPassword");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(10)
                    .HasColumnName("mobileNumber");
            });

            modelBuilder.Entity<SavingsAccount>(entity =>
            {
                entity.HasKey(e => e.SavingsAccountNo)
                    .HasName("PK_SavingsTable");

                entity.ToTable("savingsAccount");

                entity.Property(e => e.SavingsAccountNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("savingsAccountNo")
                    .HasDefaultValueSql("(format(NEXT VALUE FOR [SavingsSequence],'SA-000000#'))");

                entity.Property(e => e.AccountNumber).HasColumnName("accountNumber");

                entity.Property(e => e.MinimumBalance).HasColumnName("minimumBalance");

                entity.Property(e => e.WithdrawlLimit).HasColumnName("withdrawlLimit");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.SavingsAccounts)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__savingsAc__accou__239E4DCF");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.DestinationAccountNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("destinationAccountNo");

                entity.Property(e => e.SourceAccount)
                    .HasMaxLength(20)
                    .HasColumnName("sourceAccount");

                entity.Property(e => e.TransactionAmount).HasColumnName("transactionAmount");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("transactionDate");

                entity.Property(e => e.TransactionDescription)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("transactionDescription");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("transactionType");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__transacti__sourc__300424B4");
            });

            modelBuilder.HasSequence<int>("CorporateSequence");

            modelBuilder.HasSequence<int>("CurrentSequence");

            modelBuilder.HasSequence<int>("CustomerSequence");

            modelBuilder.HasSequence<int>("ManagerSequence");

            modelBuilder.HasSequence<int>("SavingsSequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
