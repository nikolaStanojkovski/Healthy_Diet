using HealthyDiet.Domain.Domain;
using HealthyDiet.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Repository.Implementation
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Recipe> entities;

        public RecipeRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Recipe>();
        }

        public List<Recipe> GetAll()
        {
            return entities
                .Include(z => z.Victuals)
                .Include("Victuals.Victual")
                .ToListAsync().Result;
        }

        public Recipe ReadRecipe(Guid? recipeId)
        {
            return entities
                .Include(z => z.Victuals)
                .Include("Victuals.Victual")
                .SingleOrDefaultAsync(z => z.Id.Equals(recipeId)).Result;
        }

        public Recipe CreateRecipe(Recipe entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public void UpdateRecipe(Recipe entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.entities.Update(entity);
            context.SaveChanges();
        }
    }
}
