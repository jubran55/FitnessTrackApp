using FitnessTrackApp.Models;
using FitnessTrackApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FitnessTrackApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FitnessTrackDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, FitnessTrackDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var FoodTypeList = _dbContext.MtfoodTypes.ToList();
            var FoodNutritionsList = _dbContext.MtfoodNutritions.ToList();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
