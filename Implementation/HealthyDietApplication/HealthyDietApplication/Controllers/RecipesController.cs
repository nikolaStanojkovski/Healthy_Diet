using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.DTO;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Service;
using HealthyDiet.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDietApplication.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly IVictualService victualService;

        public RecipesController(IRecipeService _recipeService,
            IVictualService _victualService)
        {
            this.recipeService = _recipeService;
            this.victualService = _victualService;
        }

        public IActionResult Index(Int64 pageNumber = 1)
        {
            // DBDataInsertion insertion = new DBDataInsertion(recipeService, victualService);
            // insertion.PopulateDatabaseRecipes();

            List<Recipe> allRecipes = recipeService.GetAllRecipes();
            List<Recipe> paginatedRecipes = recipeService.GetPaginatedRecipes(pageNumber, allRecipes);
            RecipesDTO model = new RecipesDTO
            {
                Recipes = paginatedRecipes,
                RecipesSize = allRecipes.Count,
                PageNumber = pageNumber
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult FilterRecipes(MealType mealType, Int64 preparationTime, Int64 timesCooked, Int64 noCalories, Int64 pageNumber)
        {
            List<Recipe> filteredRecipes = recipeService.FilterRecipes(mealType, preparationTime, timesCooked, noCalories, pageNumber);
            RecipesDTO model = new RecipesDTO
            {
                Recipes = filteredRecipes,
                RecipesSize = recipeService.GetAllRecipes().Count,
                PageNumber = pageNumber
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SortRecipes(Int64 sortCondition, Int64 pageNumber)
        {
            List<Recipe> sortedRecipes = recipeService.SortRecipes(sortCondition, recipeService.GetAllRecipes(), pageNumber);
            RecipesDTO model = new RecipesDTO
            {
                Recipes = sortedRecipes,
                RecipesSize = recipeService.GetAllRecipes().Count,
                PageNumber = pageNumber
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SearchRecipes(string text, Int64 pageNumber)
        {
            List<Recipe> searchedRecipes = recipeService.SearchRecipes(text, pageNumber);
            RecipesDTO model = new RecipesDTO
            {
                Recipes = searchedRecipes,
                RecipesSize = recipeService.GetAllRecipes().Count,
                PageNumber = pageNumber
            };
            return View("Index", model);
        }


        public IActionResult Details(Guid recipeId)
        {
            var model = recipeService.GetRecipe(recipeId);

            return View(model);
        }

        public IActionResult ChooseRecipeForUser(Int64 rating, Guid recipeId)
        {
            recipeService.UpdateRatingService(rating, recipeId);

            return RedirectToAction("Index", "Recipes");
        }
    }
}
