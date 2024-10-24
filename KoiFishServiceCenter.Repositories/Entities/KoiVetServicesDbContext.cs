using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class KoiVetServicesDbContext : DbContext
{
    public KoiVetServicesDbContext()
    {
    }

    public KoiVetServicesDbContext(DbContextOptions<KoiVetServicesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cost> Costs { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceHistory> ServiceHistories { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<VetSchedule> VetSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TIENVY;Initial Catalog=KoiVetServicesDB;Persist Security Info=True;User ID=sa;Password=TienVyBui-05;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cost>(entity =>
        {
            entity.HasKey(e => e.CostId).HasName("PK__Cost__8285231E38341D90");

            entity.ToTable("Cost");

            entity.Property(e => e.CostId)
                .ValueGeneratedNever()
                .HasColumnName("CostID");
            entity.Property(e => e.AdditionalFees).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Cost1)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Cost");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Service).WithMany(p => p.Costs)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Cost__ServiceID__4BAC3F29");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8FBA7F893");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customer__UserID__3A81B327");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6252EAF79");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("FeedbackID");
            entity.Property(e => e.Comments).HasMaxLength(255);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Feedback__Custom__47DBAE45");

            entity.HasOne(d => d.Service).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Feedback__Servic__48CFD27E");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD48E54F5BECE8");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("ReportID");
            entity.Property(e => e.AverageRating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.ReportDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EAEAC5DB1A");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceName).HasMaxLength(100);
        });

        modelBuilder.Entity<ServiceHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__ServiceH__4D7B4ADDCBFDAECB");

            entity.ToTable("ServiceHistory");

            entity.Property(e => e.HistoryId)
                .ValueGeneratedNever()
                .HasColumnName("HistoryID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Result).HasMaxLength(255);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.VeterinarianId).HasColumnName("VeterinarianID");

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceHistories)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ServiceHi__Custo__3F466844");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceHistories)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__ServiceHi__Servi__403A8C7D");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.ServiceHistories)
                .HasForeignKey(d => d.VeterinarianId)
                .HasConstraintName("FK__ServiceHi__Veter__412EB0B6");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__1788CCAC84B83F8E");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.Email, "UQ__UserAcco__A9D105344A60BB30").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<VetSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__VetSched__9C8A5B698156C40F");

            entity.ToTable("VetSchedule");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("ScheduleID");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.TimeSlot).HasMaxLength(50);
            entity.Property(e => e.VeterinarianId).HasColumnName("VeterinarianID");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.VetSchedules)
                .HasForeignKey(d => d.VeterinarianId)
                .HasConstraintName("FK__VetSchedu__Veter__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
