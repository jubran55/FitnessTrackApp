using FitnessTrackApp.Models;

namespace FitnessTrackApp.ViewModels
{
    public class FoodViewModel
    {
         public List<MtfoodType> FoodTypeList { get; set; }
         public List<MtfoodNutrition> FoodNutritionsList { get; set; }
    }
}
