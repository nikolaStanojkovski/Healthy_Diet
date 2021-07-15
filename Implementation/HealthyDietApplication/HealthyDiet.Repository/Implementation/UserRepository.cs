using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<HealthyDietUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<HealthyDietUser>();
        }

        public List<HealthyDietUser> GetAll()
        {
            return entities.ToListAsync().Result;
        }

        // One Entity

        public HealthyDietUser ReadUserInformation(string id)
        {
            return entities
                .Include(z => z.CommunityInfo)
                .SingleOrDefaultAsync(z => z.Id.Equals(id)).Result;
        }

        public HealthyDietUser ReadUserStatistics(string id)
        {
            return entities
                .Include(z => z.CommunityInfo)
                .Include(z => z.Statistics)
                .Include("Statistics.Victuals")
                .Include("Statistics.Victuals.Victual")
                .Include("Statistics.Diets")
                .Include("Statistics.Diets.Diet")
                .Include("Statistics.WaterIntake")
                .SingleOrDefaultAsync(z => z.Id.Equals(id)).Result;
        }

        public HealthyDietUser ReadUserFriends(string id)
        {
            return entities
                .Include(z => z.Friends)
                .Include("Friends.Friend")
                .Include(z => z.CommunityInfo)
                .SingleOrDefaultAsync(z => z.Id.Equals(id)).Result;
        }

        public void CreateUser(HealthyDietUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
        }

        public void UpdateUser(HealthyDietUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Update(entity);
            context.SaveChanges();
        }

        public void DeleteUser(HealthyDietUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
