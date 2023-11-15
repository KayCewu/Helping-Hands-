using System;
using System.Collections.Generic;
using Helping_Hands_2._0.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace Helping_Hands_2._0.Models;

public partial class HelpingHandsDbContext : ApplicationDBContext
{

    public HelpingHandsDbContext(DbContextOptions<HelpingHandsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<CareContract> CareContracts { get; set; }

    public virtual DbSet<ChronicCondition> ChronicConditions { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Gallery> Galleries { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientChronicCon> PatientChronicCons { get; set; }

    public virtual DbSet<PreferredSuburb> PreferredSuburbs { get; set; }

    public virtual DbSet<Suburb> Suburbs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VisitInfo> VisitInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KAMVA-CEWU;Database=HelpingHandsDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Business>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Business");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nponumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NPONumber");
            entity.Property(e => e.OperatingHours)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CareContract>(entity =>
        {
            entity.HasKey(e => e.CareContractId).HasName("PK__CareCont__0F67689EC8F93B0F");

            entity.ToTable("CareContract");

            entity.Property(e => e.CareContractId).HasColumnName("CareContractID");
            entity.Property(e => e.ContractAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ContractDate).HasColumnType("date");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
           
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.WoundDescription)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PatientNoNavigation).WithMany(p => p.CareContracts)
                .HasForeignKey(d => d.PatientNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CareContr__Patie__48CFD27E");
        });

        modelBuilder.Entity<ChronicCondition>(entity =>
        {
            entity.HasKey(e => e.ChronicId).HasName("PK__ChronicC__9C5E417E04A117ED");

            entity.ToTable("ChronicCondition");

            entity.Property(e => e.ChronicId).HasColumnName("ChronicID");
            entity.Property(e => e.ConditionDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ConditionName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A965F1CA30A");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityAbbrev)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CityName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gallery>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Gallery");

            entity.Property(e => e.ImagePath)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Managers__3BA2AA813A7593D2");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.HasKey(e => e.NurseCode).HasName("PK__Nurse__A60218736AE118E5");

            entity.ToTable("Nurse");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Idno)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("IDNO");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.Nurses)
                .HasForeignKey(d => d.Manager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nurse__Manager__2BFE89A6");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC366B9D5680F");

            entity.ToTable("Patient");

            entity.Property(e => e.ChronicCondition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Idno)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("IDNo");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ResAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientChronicCon>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ChronicCondition)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<PreferredSuburb>(entity =>
        {
            entity.HasKey(e => e.PrefSubId).HasName("PK__Preferre__964072517A9CE979");

            entity.ToTable("PreferredSuburb");

            entity.Property(e => e.PrefSubId).HasColumnName("PrefSubID");
            entity.Property(e => e.SuburbId).HasColumnName("SuburbID");

            entity.HasOne(d => d.NurseCodeNavigation).WithMany(p => p.PreferredSuburbs)
                .HasForeignKey(d => d.NurseCode)
                .HasConstraintName("FK__Preferred__Nurse__44FF419A");

            entity.HasOne(d => d.Suburb).WithMany(p => p.PreferredSuburbs)
                .HasForeignKey(d => d.SuburbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preferred__Subur__45F365D3");
        });

        modelBuilder.Entity<Suburb>(entity =>
        {
            entity.HasKey(e => e.SuburbId).HasName("PK__Suburb__BB2E9AE12E558DD5");

            entity.ToTable("Suburb");

            entity.Property(e => e.SuburbId).HasColumnName("SuburbID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.SuburbName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Suburbs)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Suburb__CityID__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FA8D24126");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VisitInfo>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__VisitInf__4D3AA1BEE0B2BC48");

            entity.ToTable("VisitInfo");

            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.ApproxArrivalTime)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.VisitArrivalTime)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.VisitDate).HasColumnType("date");
            entity.Property(e => e.VisitDepartTime)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.WoundProgress)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ContractNoNavigation).WithMany(p => p.VisitInfos)
                .HasForeignKey(d => d.ContractNo)
                .HasConstraintName("FK__VisitInfo__Contr__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
