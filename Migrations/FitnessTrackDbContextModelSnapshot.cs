﻿// <auto-generated />
using System;
using FitnessTrackApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessTrackApp.Migrations
{
    [DbContext(typeof(FitnessTrackDbContext))]
    partial class FitnessTrackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessTrackApp.Models.MtfoodNutrition", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FoodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double?>("DietaryFiber")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("FoodNameArabic")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FoodNameEnglish")
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("varchar(512)");

                    b.Property<int?>("FoodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("FoodTypeID");

                    b.Property<double?>("Protein")
                        .HasColumnType("float");

                    b.Property<int?>("Weight100")
                        .HasColumnType("int")
                        .HasColumnName("weight100");

                    b.HasKey("FoodId")
                        .HasName("PK__MtFoodNu__3214EC27EE34EC3B");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("MTFoodNutrition", (string)null);
                });

            modelBuilder.Entity("FitnessTrackApp.Models.MtfoodType", b =>
                {
                    b.Property<int>("FoodTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FoodTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodTypeId"));

                    b.Property<string>("TypeNameArabic")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TypeNameEnglish")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FoodTypeId")
                        .HasName("PK__MtFoodTy__516F03B50CA9EA02");

                    b.ToTable("MTFoodType", (string)null);
                });

            modelBuilder.Entity("FitnessTrackApp.Models.MvfoodNutrition", b =>
                {
                    b.Property<double?>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double?>("DietaryFiber")
                        .HasColumnType("float");

                    b.Property<int>("Expr1")
                        .HasColumnType("int");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<int>("FoodId")
                        .HasColumnType("int")
                        .HasColumnName("FoodID");

                    b.Property<string>("FoodNameArabic")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FoodNameEnglish")
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("varchar(512)");

                    b.Property<int?>("FoodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("FoodTypeID");

                    b.Property<double?>("Protein")
                        .HasColumnType("float");

                    b.Property<int?>("Weight100")
                        .HasColumnType("int")
                        .HasColumnName("weight100");

                    b.ToTable((string)null);

                    b.ToView("MVFoodNutrition", (string)null);
                });

            modelBuilder.Entity("FitnessTrackApp.Models.MtfoodNutrition", b =>
                {
                    b.HasOne("FitnessTrackApp.Models.MtfoodType", "FoodType")
                        .WithMany("MtfoodNutritions")
                        .HasForeignKey("FoodTypeId")
                        .HasConstraintName("FK_MtFoodNutrition_MtFoodType");

                    b.Navigation("FoodType");
                });

            modelBuilder.Entity("FitnessTrackApp.Models.MtfoodType", b =>
                {
                    b.Navigation("MtfoodNutritions");
                });
#pragma warning restore 612, 618
        }
    }
}
