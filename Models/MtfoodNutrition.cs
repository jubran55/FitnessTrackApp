using System;
using System.Collections.Generic;

namespace FitnessTrackApp.Models;

public partial class MtfoodNutrition
{
    public int FoodId { get; set; }

    public string? FoodNameEnglish { get; set; }

    public string? FoodNameArabic { get; set; }

    public int? FoodTypeId { get; set; }

    public int? Weight100 { get; set; }

    public double? Calories { get; set; }

    public double? Protein { get; set; }

    public double? Carbohydrates { get; set; }

    public double? Fats { get; set; }

    public double? DietaryFiber { get; set; }

    public virtual MtfoodType? FoodType { get; set; }
}
