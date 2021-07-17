using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Repository;
using HealthyDiet.Repository.Interface;
using HealthyDietApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDietApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Victual> victualRepository;
        private readonly IRepository<RecipeVictual> recipeVictualRepository;
        private readonly IRecipeRepository recipeRepository;
        private readonly IDietRepository dietRepository;

        public HomeController(ILogger<HomeController> logger,
                    IRepository<Victual> _victualRepository,
                    IRepository<RecipeVictual> _recipeVictualRepository,
                    IRecipeRepository _recipeRepository,
                    IDietRepository _dietRepository)
        {
            _logger = logger;

            this.victualRepository = _victualRepository;
            this.recipeRepository = _recipeRepository;
            this.recipeVictualRepository = _recipeVictualRepository;
            this.dietRepository = _dietRepository;
        }

        public IActionResult Index()
        {
            // DBDataInsertion dBDataInsertion = new DBDataInsertion(recipeRepository, dietRepository, victualRepository, recipeVictualRepository);
            // dBDataInsertion.PopualteDatabase();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
