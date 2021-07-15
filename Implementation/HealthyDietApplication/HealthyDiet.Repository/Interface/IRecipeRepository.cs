using HealthyDiet.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Repository.Interface
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();

        // For one entity

        Recipe ReadRecipe(Guid? dietId);

        Recipe CreateRecipe(Recipe entity);

        void UpdateRecipe(Recipe entity);
    }
}
