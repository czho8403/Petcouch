using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab0726_Petouchv2.Models;

public partial class Lab0712dbContext : DbContext
{
    public Lab0712dbContext()
    {
    }

    public Lab0712dbContext(DbContextOptions<Lab0712dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lab00> Lab00s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=lab0712db;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lab00>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lab00__3213E83F02EA8D1B");

            entity.ToTable("lab00");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasMaxLength(20)
                .HasColumnName("data");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
