using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackApp.Models;

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

    public virtual DbSet<MVfoodNutrition> VmfoodNutritions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-USI4BRO;Database=FitnessTrackDB;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MtfoodNutrition>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__MtFoodNu__3214EC27EE34EC3B");

            entity.Property(e => e.FoodId).ValueGeneratedNever();

            entity.HasOne(d => d.FoodType).WithMany(p => p.MtfoodNutritions).HasConstraintName("FK_MtFoodNutrition_MtFoodType");
        });

        modelBuilder.Entity<MtfoodType>(entity =>
        {
            entity.HasKey(e => e.FoodTypeId).HasName("PK__MtFoodTy__516F03B50CA9EA02");

            entity.Property(e => e.FoodTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MVfoodNutrition>(entity =>
        {
            entity.ToView("MVFoodNutrition");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
