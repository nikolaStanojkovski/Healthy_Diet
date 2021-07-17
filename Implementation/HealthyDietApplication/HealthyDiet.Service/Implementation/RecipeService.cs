using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Implementation
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository _recipeRepository)
        {
            this.recipeRepository = _recipeRepository;
        }

        public List<Recipe> GetAllRecipes()
        {
            return recipeRepository.GetAll();
        }

        public List<Recipe> GetPaginatedRecipes(long pageNumber, List<Recipe> recipes)
        {
            long secondOffset = pageNumber * 9;
            long firstOffset = secondOffset - 9;
            int pageSize = 9;
            long checkOffset = (int)(recipes.Count / 9);

            if (checkOffset == 0) // first page check
                pageSize = recipes.Count;
            else if ((checkOffset + 1) == pageNumber) // last page check
            {
                long lastOffset = (int)(recipes.Count % firstOffset);
                if (lastOffset < 9)
                    pageSize = (int)lastOffset;
            }

            return recipes.GetRange((int)firstOffset, pageSize);
        }

        public List<Recipe> FilterRecipes(MealType mealType, long preparationTime, long timesCooked, long noCalories, Int64 pageNumber)
        {
            List<Recipe> recipes = GetAllRecipes();

            if(mealType != MealType.UNSELECTED)
                recipes = recipes.Where(z => z.MealType.Equals(mealType)).ToList();

            if (preparationTime != 0)
                recipes = recipes.Where(z => z.PreparationTime <= preparationTime).ToList();

            if (timesCooked != 0)
                recipes = recipes.Where(z => z.TimesCooked >= timesCooked).ToList();

            if (noCalories != 0)
                recipes = recipes.Where(z => z.Victuals.Sum(
                    t => t.Quantity * t.Victual.NumberCalories) <= noCalories).ToList();

            return recipes;
        }

        public List<Recipe> SortRecipes(long sortCondition, List<Recipe> recipes, Int64 pageNumber)
        {
            if (sortCondition == 1) // popularity
                recipes = recipes.OrderByDescending(z => z.TimesCooked).ToList();
            else // rating
                recipes = recipes.OrderByDescending(z => (z.FeedbackSum / z.NoFeedbacks)).ToList();

            return recipes;
        }

        public List<Recipe> SearchRecipes(string text, Int64 pageNumber)
        {
            List<Recipe> recipes = GetAllRecipes();

            List<Recipe> filteredRecipes = new List<Recipe>();

            if (recipes.Where(z => z.Name.Contains(text)).Count() != 0)
                filteredRecipes.AddRange(recipes.Where(z => z.Name.Contains(text)).ToList());

            if (recipes.Where(z => z.ShortDescription.Contains(text)).Count() != 0)
                filteredRecipes.AddRange(recipes.Where(z => z.ShortDescription.Contains(text) 
                && filteredRecipes.Where(t => t.Id.Equals(z.Id)).Count() == 0).ToList());

            if (recipes.Where(z => z.Preparation.Contains(text)).Count() != 0)
                filteredRecipes.AddRange(recipes.Where(z => z.Preparation.Contains(text)
                && filteredRecipes.Where(t => t.Id.Equals(z.Id)).Count() == 0).ToList());

            if (recipes.Where(z => z.Victuals.Where(t => t.Victual.Name.Contains(text)).Count() != 0).Count() != 0)
                filteredRecipes.AddRange(recipes.Where(z => z.Victuals.Where(t => t.Victual.Name.Contains(text)).Count() != 0
                && filteredRecipes.Where(t => t.Id.Equals(z.Id)).Count() == 0).ToList());

            return filteredRecipes;
        }


        public Recipe CreateRecipe(Recipe recipe)
        {
            if (recipe != null)
            {
                recipeRepository.CreateRecipe(recipe);
                return recipe;
            }
            else
                return null;
        }

        public Recipe GetRecipe(Guid? recipeId)
        {
            return recipeRepository.ReadRecipe(recipeId);
        }

        public void UpdateRatingService(Int64 rating, Guid recipeId)
        {
            Recipe recipe = recipeRepository.ReadRecipe(recipeId);

            recipe.FeedbackSum += rating;
            recipe.NoFeedbacks++;
            recipe.TimesCooked++;

            recipeRepository.UpdateRecipe(recipe);
        }
    }
}
