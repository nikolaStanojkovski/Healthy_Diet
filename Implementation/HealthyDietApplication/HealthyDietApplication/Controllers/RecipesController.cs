using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.DTO;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Repository;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HealthyDietApplication.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRepository<Victual> victualRepository;
        private readonly IRepository<RecipeVictual> recipeVictualRepository;
        private readonly IRepository<Day> dayRepository;
        private readonly IRepository<DayVictual> dayVictualRepository;
        private readonly IRecipeRepository recipeRepository;
        private readonly IDietRepository dietRepository;

        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeRepository _recipeRepository,
            IDietRepository _dietRepository,
            IRepository<Victual> _victualRepository,
            IRepository<RecipeVictual> _recipeVictualRepository,
            IRepository<Day> _dayRepository,
            IRepository<DayVictual> _dayVictualRepository,
            IRecipeService _recipeService)
        {
            this.recipeRepository = _recipeRepository;
            this.dietRepository = _dietRepository;
            this.victualRepository = _victualRepository;
            this.recipeVictualRepository = _recipeVictualRepository;
            this.dayRepository = _dayRepository;
            this.dayVictualRepository = _dayVictualRepository;

            this.recipeService = _recipeService;
        }

        public IActionResult Index(Int64 pageNumber = 1, bool sorted = false, int sortCondition = 2)
        {
            // DBDataInsertion insertion = new DBDataInsertion(recipeRepository, dietRepository, victualRepository, recipeVictualRepository, dayRepository, dayVictualRepository);
            // insertion.PopualteDatabase();

            List<Recipe> allRecipes = new List<Recipe>();
            if (sorted)
                allRecipes = recipeService.SortRecipes(sortCondition, recipeService.GetAllRecipes(), pageNumber);
            else
                allRecipes = recipeService.GetAllRecipes();

            List<Recipe> paginatedRecipes = recipeService.GetPaginatedRecipes(pageNumber, allRecipes);
            RecipesDTO model = new RecipesDTO
            {
                Recipes = paginatedRecipes,
                RecipesSize = allRecipes.Count,
                PageNumber = pageNumber,
                AreFiltered = false,
                AreSorted = sorted,
                SortCondition = sortCondition
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
                PageNumber = pageNumber,
                AreFiltered = true,
                AreSorted = false,
                SortCondition = 2
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SortRecipes(Int64 sortCondition, Int64 pageNumber)
        {
            List<Recipe> sortedRecipes =
                recipeService.GetPaginatedRecipes(pageNumber, recipeService.SortRecipes(sortCondition, recipeService.GetAllRecipes(), pageNumber));
            RecipesDTO model = new RecipesDTO
            {
                Recipes = sortedRecipes,
                RecipesSize = recipeService.GetAllRecipes().Count,
                PageNumber = pageNumber,
                AreFiltered = false,
                AreSorted = true,
                SortCondition = (int)sortCondition
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
                PageNumber = pageNumber,
                AreFiltered = true,
                AreSorted = false,
                SortCondition = 2
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
