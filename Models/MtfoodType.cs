using System;
using System.Collections.Generic;

namespace FitnessTrackApp.Models;

public partial class MtfoodType
{
    public int FoodTypeId { get; set; }

    public string TypeNameEnglish { get; set; } = null!;

    public string? TypeNameArabic { get; set; }

    public virtual ICollection<MtfoodNutrition> MtfoodNutritions { get; set; } = new List<MtfoodNutrition>();
}
