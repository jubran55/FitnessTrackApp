using System;
using System.Collections.Generic;
using FitnessTrackApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackApp.Data;

public partial class FitnessTrackDbContext : DbContext
{
    public FitnessTrackDbContext()
    {
    }

    public FitnessTrackDbContext(DbContextOptions<FitnessTrackDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MtfoodNutrition> MtfoodNutritions { get; set; }

    public virtual DbSet<MtfoodType> MtfoodTypes { get; set; }

    public virtual DbSet<MvfoodNutrition> MvfoodNutritions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=db9783.public.databaseasp.net; Database=db9783; User Id=db9783; Password=8Mi=c#C7-E6g; Encrypt=False; MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MtfoodNutrition>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__MtFoodNu__3214EC27EE34EC3B");

            entity.ToTable("MTFoodNutrition");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.FoodNameArabic).HasMaxLength(255);
            entity.Property(e => e.FoodNameEnglish)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.FoodTypeId).HasColumnName("FoodTypeID");
            entity.Property(e => e.Weight100).HasColumnName("weight100");

            entity.HasOne(d => d.FoodType).WithMany(p => p.MtfoodNutritions)
                .HasForeignKey(d => d.FoodTypeId)
                .HasConstraintName("FK_MtFoodNutrition_MtFoodType");
        });

        modelBuilder.Entity<MtfoodType>(entity =>
        {
            entity.HasKey(e => e.FoodTypeId).HasName("PK__MtFoodTy__516F03B50CA9EA02");

            entity.ToTable("MTFoodType");

            entity.Property(e => e.FoodTypeId).HasColumnName("FoodTypeID");
            entity.Property(e => e.TypeNameArabic).HasMaxLength(255);
            entity.Property(e => e.TypeNameEnglish).HasMaxLength(255);
        });

        modelBuilder.Entity<MvfoodNutrition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MVFoodNutrition");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.FoodNameArabic).HasMaxLength(255);
            entity.Property(e => e.FoodNameEnglish)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.FoodTypeId).HasColumnName("FoodTypeID");
            entity.Property(e => e.Weight100).HasColumnName("weight100");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
