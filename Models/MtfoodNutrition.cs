using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackApp.Models;

[Table("MTFoodNutrition")]
public partial class MtfoodNutrition
{
    [Key]
    [Column("FoodID")]
    public int FoodId { get; set; }

    [StringLength(512)]
    [Unicode(false)]
    public string? FoodNameEnglish { get; set; }

    [StringLength(255)]
    public string? FoodNameArabic { get; set; }

    [Column("FoodTypeID")]
    public int? FoodTypeId { get; set; }

    [Column("weight100")]
    public int? Weight100 { get; set; }

    public double? Calories { get; set; }

    public double? Protein { get; set; }

    public double? Carbohydrates { get; set; }

    public double? Fats { get; set; }

    public double? DietaryFiber { get; set; }

    [ForeignKey("FoodTypeId")]
    [InverseProperty("MtfoodNutritions")]
    public virtual MtfoodType? FoodType { get; set; }
}
