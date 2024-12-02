using FitnessTrackApp.Data;
using FitnessTrackApp.Models;
using FitnessTrackApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using SelectPdf;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.ViewEngines;


namespace FitnessTrackApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FitnessTrackDbContext _dbContext;
        private readonly ICompositeViewEngine _viewEngine;

        public HomeController(ILogger<HomeController> logger, FitnessTrackDbContext dbContext , ICompositeViewEngine viewEngine)
        {
            _logger = logger;
            _dbContext = dbContext;
            _viewEngine = viewEngine;
        }

        public IActionResult Index()
        {


            var FoodTypeList = _dbContext.MtfoodTypes.ToList() ?? new List<MtfoodType>();
            var FoodNutritionsList = _dbContext.MtfoodNutritions.ToList() ?? new List<MtfoodNutrition>();

            var model = new FoodViewModel
            {
                FoodTypeList = FoodTypeList,
                FoodNutritionsList = FoodNutritionsList
            };
           
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetFoodItemsByType(int foodTypeId)
        {
            var foodItems = _dbContext.MtfoodNutritions
                .Where(f => f.FoodTypeId == foodTypeId).ToList();

            return Json(foodItems);
        }

        [HttpPost]
        public IActionResult CalculateNutrition(int foodId, int weight)
        {
            var foodItem = _dbContext.MtfoodNutritions.FirstOrDefault(f => f.FoodId == foodId);

            if (foodItem == null)
            {
                return NotFound();
            }

            var nutrition = new
            {
                Calories = (foodItem.Calories * weight) / 100,
                Protein = (foodItem.Protein * weight) / 100,
                Carbs = (foodItem.Carbohydrates * weight) / 100,
                Fats = (foodItem.Fats * weight) / 100,
                DietaryFiber = (foodItem.DietaryFiber * weight) / 100
            };

            return Json(nutrition);
        }

        [HttpPost]
        public IActionResult AddFoodType(string typeNameArabic, string typeNameEnglish)
        {
            // Add the new food type to the database
            var newFoodType = new MtfoodType
            {
                TypeNameArabic = typeNameArabic,
                TypeNameEnglish = typeNameEnglish
            };
            _dbContext.MtfoodTypes.Add(newFoodType);
            _dbContext.SaveChanges();

            // Return the new food type ID and names
            return Json(new { foodTypeId = newFoodType.FoodTypeId, typeNameArabic = newFoodType.TypeNameArabic, typeNameEnglish = newFoodType.TypeNameEnglish });
        }

        [HttpPost]
        public IActionResult AddFoodItem(string foodNameEnglish, string foodNameArabic, int foodTypeId, double calories, double protein, double carbohydrates, double fats, double dietaryFiber)
        {
            // Create a new food item
            var newFoodItem = new MtfoodNutrition
            {
                FoodNameEnglish = foodNameEnglish,
                FoodNameArabic = foodNameArabic,
                FoodTypeId = foodTypeId,
                Calories = calories,
                Protein = protein,
                Carbohydrates = carbohydrates,
                Fats = fats,
                DietaryFiber = dietaryFiber
            };

            // Add the new food item to the database
            _dbContext.MtfoodNutritions.Add(newFoodItem);
            _dbContext.SaveChanges();

            // Return the new food item ID and names
            return Json(new { foodId = newFoodItem.FoodId, foodNameEnglish = newFoodItem.FoodNameEnglish, foodNameArabic = newFoodItem.FoodNameArabic });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult GeneratePdf([FromBody] HtmlContentModel model)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(model.Html);
            byte[] pdf = doc.Save();
            doc.Close();

            return File(pdf, "application/pdf11", "foodTable.pdf");
        }
    

  


}
    public class HtmlContentModel
    {
        public string Html { get; set; }
    }
}
