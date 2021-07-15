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
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Diet> entities;

        public DietRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Diet>();
        }

        public List<Diet> GetAll()
        {
            return entities
                .Include(z => z.Days)
                .Include("Days.Victuals")
                .Include("Days.Victuals.Victual")
                .Include(z => z.Diets)
                .ToListAsync().Result;
        }

        public Diet ReadDiet(Guid? dietId)
        {
            return entities
                .Include(z => z.Days)
                .Include("Days.Victuals")
                .Include("Days.Victuals.Victual")
                .Include(z => z.Diets)
                .SingleOrDefaultAsync(z => z.Id.Equals(dietId)).Result;
        }

        public Diet CreateDiet(Diet entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public void UpdateDiet(Diet entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.entities.Update(entity);
            context.SaveChanges();
        }
    }
}
