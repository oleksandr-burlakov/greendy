using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Greendy.DAL.Entities;

public partial class GreendyContext : DbContext
{
    public GreendyContext()
    {
    }

    public GreendyContext(DbContextOptions<GreendyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrackStorage> TrackStorages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=greendy;Username=postgres;Password=qwer1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<TrackStorage>(entity =>
        {
            entity.ToTable("TrackStorage");

            entity.Property(e => e.TrackStorageId).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
