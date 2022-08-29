using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFLayerImpl.Models
{
    public partial class db_TicketLoggingContext : IdentityDbContext
    {
        public db_TicketLoggingContext()
        {
        }

        public db_TicketLoggingContext(DbContextOptions<db_TicketLoggingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AKSHYA-BL\\SQLEXPRESS;Initial Catalog=db_TicketLogging;Integrated Security=True");
*/            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("PK__Employee__C190176BAE9FEE9F");

                entity.ToTable("Employee");

                entity.Property(e => e.Eid)
                    .HasMaxLength(10)
                    .HasColumnName("EId");

                entity.Property(e => e.Dept)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(30)
                    .HasColumnName("Employee_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("Hire_Date");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId).HasMaxLength(10);

                entity.Property(e => e.LoggedBy).HasMaxLength(10);

                entity.Property(e => e.RaisedDate).HasColumnType("date");

                entity.Property(e => e.Resolution).HasMaxLength(40);

                entity.Property(e => e.ResolvedBy).HasMaxLength(40);

                entity.Property(e => e.ResolvedDate).HasColumnType("date");

                entity.Property(e => e.Severity)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TicketDescription).HasMaxLength(40);

                entity.Property(e => e.TicketStatus).HasMaxLength(10);

                entity.HasOne(d => d.LoggedByNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.LoggedBy)
                    .HasConstraintName("EmpId_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
