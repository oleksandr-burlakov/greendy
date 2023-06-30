using System;
using System.Collections.Generic;
using Greendy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greendy.Persistance;

public partial class GreendyContext : DbContext
{
    public GreendyContext()
    {
    }

    public GreendyContext(DbContextOptions<GreendyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TrackItem> TrackItems { get; set; }

    public virtual DbSet<TrackItemCategory> TrackItemCategories { get; set; }

    public virtual DbSet<TrackStorage> TrackStorages { get; set; }

    public virtual DbSet<TrackStorageItem> TrackStorageItems { get; set; }

    public virtual DbSet<TrackStorageSubscription> TrackStorageSubscriptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserTrackItem> UserTrackItems { get; set; }

    public virtual DbSet<UserTrackItemHistory> UserTrackItemHistories { get; set; }

    public virtual DbSet<UserTrackItemHistoryAction> UserTrackItemHistoryActions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=greendy;Username=postgres;Password=qwer1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TrackItem>(entity =>
        {
            entity.ToTable("TrackItem");

            entity.Property(e => e.TrackItemId).ValueGeneratedNever();
            entity.Property(e => e.ImagePath).HasMaxLength(250);
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(80);

            entity.HasOne(d => d.TrackItemCategory).WithMany(p => p.TrackItems)
                .HasForeignKey(d => d.TrackItemCategoryId)
                .HasConstraintName("FK_TrackItem_TrackItemCategory");
        });

        modelBuilder.Entity<TrackItemCategory>(entity =>
        {
            entity.HasKey(e => e.TrackItemCategoryId).HasName("TrackItemCategory_PK");

            entity.ToTable("TrackItemCategory");

            entity.Property(e => e.TrackItemCategoryId).ValueGeneratedNever();
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(80);
        });

        modelBuilder.Entity<TrackStorage>(entity =>
        {
            entity.ToTable("TrackStorage");

            entity.Property(e => e.TrackStorageId).ValueGeneratedNever();
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(80);

            entity.HasOne(d => d.Author).WithMany(p => p.TrackStorages)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackStorage_User");
        });

        modelBuilder.Entity<TrackStorageItem>(entity =>
        {
            entity.ToTable("TrackStorageItem");

            entity.Property(e => e.TrackStorageItemId).ValueGeneratedNever();

            entity.HasOne(d => d.TrackItem).WithMany(p => p.TrackStorageItems)
                .HasForeignKey(d => d.TrackItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackStorageItem_TrackItem");

            entity.HasOne(d => d.TrackStorage).WithMany(p => p.TrackStorageItems)
                .HasForeignKey(d => d.TrackStorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackStorageItem_TrackStorage");
        });

        modelBuilder.Entity<TrackStorageSubscription>(entity =>
        {
            entity.ToTable("TrackStorageSubscription");

            entity.Property(e => e.TrackStorageSubscriptionId).ValueGeneratedNever();

            entity.HasOne(d => d.TrackStorage).WithMany(p => p.TrackStorageSubscriptions)
                .HasForeignKey(d => d.TrackStorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackStorageSubscription_TrackStorage");

            entity.HasOne(d => d.User).WithMany(p => p.TrackStorageSubscriptions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackStorageSubscription_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(128);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Salt).HasMaxLength(128);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        });

        modelBuilder.Entity<UserTrackItem>(entity =>
        {
            entity.ToTable("UserTrackItem");

            entity.Property(e => e.UserTrackItemId).ValueGeneratedNever();
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.TrackItem).WithMany(p => p.UserTrackItems)
                .HasForeignKey(d => d.TrackItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTrackItem_TrackItem");

            entity.HasOne(d => d.User).WithMany(p => p.UserTrackItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTrackItem_User");
        });

        modelBuilder.Entity<UserTrackItemHistory>(entity =>
        {
            entity.HasKey(e => e.UserTrackItemHistoryActionId);

            entity.ToTable("UserTrackItemHistory");

            entity.Property(e => e.UserTrackItemHistoryActionId).ValueGeneratedNever();

            entity.HasOne(d => d.UserTrackItemHistoryAction).WithOne(p => p.UserTrackItemHistory)
                .HasForeignKey<UserTrackItemHistory>(d => d.UserTrackItemHistoryActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTrackItemHistory_UserTrackItemHistoryAction");

            entity.HasOne(d => d.UserTrackItem).WithMany(p => p.UserTrackItemHistories)
                .HasForeignKey(d => d.UserTrackItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTrackItemHistory_UserTrackItem");
        });

        modelBuilder.Entity<UserTrackItemHistoryAction>(entity =>
        {
            entity.ToTable("UserTrackItemHistoryAction");

            entity.Property(e => e.UserTrackItemHistoryActionId).ValueGeneratedNever();
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
