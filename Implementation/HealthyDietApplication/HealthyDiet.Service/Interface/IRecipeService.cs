using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Interface
{
    public interface IRecipeService
    {
        public List<Recipe> GetAllRecipes();

        public List<Recipe> GetPaginatedRecipes(Int64 pageNumber, List<Recipe> recipes);

        // Filters and sorting

        public List<Recipe> FilterRecipes(MealType mealType, Int64 preparationTime, Int64 timesCooked, Int64 noCalories, Int64 pageNumber);

        public List<Recipe> SortRecipes(Int64 sortCondition, List<Recipe> recipes, Int64 pageNumber);

        public List<Recipe> SearchRecipes(string text, Int64 pageNumber);


        public Recipe GetRecipe(Guid? recipeId);

        public Recipe CreateRecipe(Recipe recipe);

        public void UpdateRatingService(Int64 rating, Guid recipeId);
    }
}
