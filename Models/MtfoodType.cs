using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackApp.Models;

[Table("MTFoodType")]
public partial class MtfoodType
{
    [Key]
    [Column("FoodTypeID")]
    public int FoodTypeId { get; set; }

    [StringLength(255)]
    public string TypeNameEnglish { get; set; } = null!;

    [StringLength(255)]
    public string TypeNameArabic { get; set; } = null!;

    [InverseProperty("FoodType")]
    public virtual ICollection<MtfoodNutrition> MtfoodNutritions { get; set; } = new List<MtfoodNutrition>();
}
