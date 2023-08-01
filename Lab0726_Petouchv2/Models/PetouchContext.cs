using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab0726_Petouchv2.Models;

public partial class PetouchContext : DbContext
{
    public PetouchContext()
    {
    }

    public PetouchContext(DbContextOptions<PetouchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptCaseStatus> AdoptCaseStatuses { get; set; }

    public virtual DbSet<Adoption> Adoptions { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<HospitalCaseStatus> HospitalCaseStatuses { get; set; }

    public virtual DbSet<LostCaseStatus> LostCaseStatuses { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Mytable> Mytables { get; set; }

    public virtual DbSet<PetLost> PetLosts { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reply> Replies { get; set; }

    public virtual DbSet<Shelter> Shelters { get; set; }

    public virtual DbSet<ShelterCaseStatus> ShelterCaseStatuses { get; set; }
	public object Adoptstatus { get; internal set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Petouch;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptCaseStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__AdoptCas__C8EE2043A54013DC");

            entity.ToTable("AdoptCaseStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.AdId).HasColumnName("AdID");
            entity.Property(e => e.CloseCase).HasDefaultValueSql("((0))");
            entity.Property(e => e.Collection).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ad).WithMany(p => p.AdoptCaseStatuses)
                .HasForeignKey(d => d.AdId)
                .HasConstraintName("FK__AdoptCaseS__AdID__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.AdoptCaseStatuses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AdoptCase__UserI__403A8C7D");
        });

        modelBuilder.Entity<Adoption>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("PK__Adoption__7130D58E823BB8FC");

            entity.ToTable("Adoption");

            entity.Property(e => e.AdId).HasColumnName("AdID");
            entity.Property(e => e.AdCaseId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasComputedColumnSql("('AD'+right('00000'+CONVERT([varchar](10),[AdID]),(5)))", false)
                .HasColumnName("AdCaseID");
            entity.Property(e => e.Feature).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(5);
            entity.Property(e => e.Ligation).HasMaxLength(5);
            entity.Property(e => e.Location).HasMaxLength(30);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PetAge).HasMaxLength(5);
            entity.Property(e => e.PetBreed).HasMaxLength(30);
            entity.Property(e => e.PetName).HasMaxLength(30);
            entity.Property(e => e.PetSize).HasMaxLength(5);
            entity.Property(e => e.PetType).HasMaxLength(10);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Adoption__Member__2A4B4B5E");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Contact");

            entity.Property(e => e.Ctemail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTEmail");
            entity.Property(e => e.Ctperson)
                .HasMaxLength(30)
                .HasColumnName("CTPerson");
            entity.Property(e => e.Ctphone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CTPhone");
            entity.Property(e => e.Ctpicture1)
                .HasMaxLength(200)
                .HasColumnName("CTPicture1");
            entity.Property(e => e.Ctpicture2)
                .HasMaxLength(200)
                .HasColumnName("CTPicture2");
            entity.Property(e => e.Ctpicture3)
                .HasMaxLength(200)
                .HasColumnName("CTPicture3");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Contact__UserID__2F10007B");
        });

        modelBuilder.Entity<HospitalCaseStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Hospital__C8EE204339EEA7D6");

            entity.ToTable("HospitalCaseStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.CloseCase).HasDefaultValueSql("((0))");
            entity.Property(e => e.Collection).HasDefaultValueSql("((0))");
            entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Hospital).WithMany(p => p.HospitalCaseStatuses)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__HospitalC__Hospi__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.HospitalCaseStatuses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HospitalC__UserI__5DCAEF64");
        });

        modelBuilder.Entity<LostCaseStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__LostCase__C8EE20434B16BD0F");

            entity.ToTable("LostCaseStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.CloseCase).HasDefaultValueSql("((0))");
            entity.Property(e => e.Collection).HasDefaultValueSql("((0))");
            entity.Property(e => e.LoId).HasColumnName("LoID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Lo).WithMany(p => p.LostCaseStatuses)
                .HasForeignKey(d => d.LoId)
                .HasConstraintName("FK__LostCaseSt__LoID__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.LostCaseStatuses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__LostCaseS__UserI__45F365D3");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Membersh__1788CCAC1ADB9C57");

            entity.ToTable("Membership");

            entity.HasIndex(e => e.Email, "UC_Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AdoptCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.Birth)
                .HasDefaultValueSql("('1900-01-01')")
                .HasColumnType("date");
            entity.Property(e => e.ChkEmailCode)
                .HasMaxLength(50)
                .HasColumnName("ChkEMailCode");
            entity.Property(e => e.ChkEmailCodeTimeout)
                .HasColumnType("datetime")
                .HasColumnName("ChkEMailCodeTimeout");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NickName).HasMaxLength(50);
            entity.Property(e => e.NickNameV2)
                .HasMaxLength(50)
                .HasComputedColumnSql("(case when [NickName] IS NOT NULL then [NickName] else [UserName] end)", false)
                .HasColumnName("NickName_V2");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Sex).HasMaxLength(50);
            entity.Property(e => e.TraceCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        modelBuilder.Entity<Mytable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__mytable__3214EC273DD4321E");

            entity.ToTable("mytable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.執照類別).HasMaxLength(5);
            entity.Property(e => e.字號).HasMaxLength(20);
            entity.Property(e => e.機構名稱).HasMaxLength(25);
            entity.Property(e => e.機構地址).HasMaxLength(35);
            entity.Property(e => e.機構電話).HasMaxLength(25);
            entity.Property(e => e.狀態).HasMaxLength(5);
            entity.Property(e => e.發照日期).HasColumnType("date");
            entity.Property(e => e.縣市).HasMaxLength(5);
            entity.Property(e => e.負責獸醫).HasMaxLength(5);
        });

        modelBuilder.Entity<PetLost>(entity =>
        {
            entity.HasKey(e => e.LoId).HasName("PK__PetLost__4E4965B754395562");

            entity.ToTable("PetLost");

            entity.Property(e => e.LoId).HasColumnName("LoID");
            entity.Property(e => e.Feature).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(5);
            entity.Property(e => e.LostId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasComputedColumnSql("('AD'+right('00000'+CONVERT([varchar](10),[LoID]),(5)))", false)
                .HasColumnName("LostID");
            entity.Property(e => e.LostLocation).HasMaxLength(30);
            entity.Property(e => e.LostTime).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PetAge).HasMaxLength(5);
            entity.Property(e => e.PetBreed).HasMaxLength(30);
            entity.Property(e => e.PetName).HasMaxLength(30);
            entity.Property(e => e.PetSize).HasMaxLength(5);
            entity.Property(e => e.PetType).HasMaxLength(10);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.PetLosts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PetLost__UserID__31EC6D26");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA126038FC1052B9");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.PublishTime).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Posts__UserID__398D8EEE");
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__Replies__C25E462905324C7C");

            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.PublishTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.Replies)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Replies__PostID__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany(p => p.Replies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Replies__UserID__3C69FB99");
        });

        modelBuilder.Entity<Shelter>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Shelter__CA195970421385B3");

            entity.ToTable("Shelter");

            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.Saddress)
                .HasMaxLength(50)
                .HasColumnName("SAddress");
            entity.Property(e => e.Sgender)
                .HasMaxLength(5)
                .HasColumnName("SGender");
            entity.Property(e => e.Slocation)
                .HasMaxLength(30)
                .HasColumnName("SLocation");
            entity.Property(e => e.SpetAge)
                .HasMaxLength(5)
                .HasColumnName("SPetAge");
            entity.Property(e => e.SpetBreed)
                .HasMaxLength(30)
                .HasColumnName("SPetBreed");
            entity.Property(e => e.SpetColour)
                .HasMaxLength(20)
                .HasColumnName("SPetColour");
            entity.Property(e => e.SpetSize)
                .HasMaxLength(5)
                .HasColumnName("SPetSize");
            entity.Property(e => e.SpetType)
                .HasMaxLength(10)
                .HasColumnName("SPetType");
            entity.Property(e => e.Sphone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SPhone");
            entity.Property(e => e.Spicture)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SPicture");
        });

        modelBuilder.Entity<ShelterCaseStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ShelterC__C8EE20430886E9B3");

            entity.ToTable("ShelterCaseStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.CloseCase).HasDefaultValueSql("((0))");
            entity.Property(e => e.Collection).HasDefaultValueSql("((0))");
            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.ShelterCaseStatuses)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__ShelterCase__SID__4CA06362");

            entity.HasOne(d => d.User).WithMany(p => p.ShelterCaseStatuses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ShelterCa__UserI__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
