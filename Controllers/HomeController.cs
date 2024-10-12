using FitnessTrackApp.Models;
using FitnessTrackApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FitnessTrackApp.Controllers
{
    //Scaffold-DbContext "Server=DESKTOP-USI4BRO;Database=FitnessTrackDB;Trusted_Connection=True;Trust Server Certificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force  -DataAnnotations
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FitnessTrackDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger , FitnessTrackDbContext dbContext)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult GetFoodType()
        //{
            
        //}


    }
}
