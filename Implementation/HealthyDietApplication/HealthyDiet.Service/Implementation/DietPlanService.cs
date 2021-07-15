using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthyDiet.Service.Implementation
{
    public class DietPlanService : IDietPlanService
    {
        private readonly IDietRepository dietRepository;
        private readonly IUserRepository userRepository;
        private readonly IRepository<Day> dayRepository;
        private readonly IRepository<DayVictual> dayDietRepository;
        private readonly IRepository<UserDiet> userDietRepository;
        private readonly IRepository<Victual> victualRepository;

        public DietPlanService(IDietRepository _dietRepository,
            IRepository<Day> _dayDietRepository,
            IRepository<DayVictual> _dayRepository,
            IRepository<UserDiet> _userDietRepository,
            IUserRepository _userRepository,
            IRepository<Victual> _victualRepository)
        {
            this.dietRepository = _dietRepository;
            this.dayDietRepository = _dayRepository;
            this.dayRepository = _dayDietRepository;
            this.userDietRepository = _userDietRepository;
            this.userRepository = _userRepository;
            this.victualRepository = _victualRepository;
        }

        public Diet CreateDiet(string Name, string Description, string PictureURL, double Intensity, long WeightLoss, long LengthDays, ICollection<Day> Days)
        {
            Diet newDiet = new Diet
            {
                Id = Guid.NewGuid(),
                Name = Name,
                PictureURL = PictureURL,
                Description = Description,
                Intensity = Intensity,
                WeightLoss = WeightLoss,
                LengthDays = LengthDays,
                Days = Days
            };

            dietRepository.CreateDiet(newDiet);

            return newDiet;
        }


        public List<Diet> FilterDiets(Int64 dietIntensity, Int64 weightLoss, Int64 lengthDays, Int64 noCalories, Int64 pageNumber)
        {
            List<Diet> dietPlans = GetAllDiets();

            if (dietIntensity != 0)
                dietPlans = dietPlans.Where(z => z.Intensity >= dietIntensity).ToList();

            if (weightLoss != 0)
                dietPlans = dietPlans.Where(z => z.WeightLoss >= weightLoss).ToList();

            if (lengthDays != 0)
                dietPlans = dietPlans.Where(z => z.LengthDays == lengthDays).ToList();

            if (noCalories != 0)
                dietPlans = dietPlans.Where(z => z.Days.Average(t => t.Victuals
                .Sum(g => g.Quantity * g.Victual.NumberCalories)) <= ((double)noCalories)).ToList();

            return GetPaginatedDiets(pageNumber, dietPlans);
        }

        public List<Diet> SortDiets(long sortCondition, List<Diet> sortNeeded, Int64 pageNumber)
        {
            if (sortCondition == 1) // popularity
                sortNeeded = sortNeeded.OrderByDescending(z => z.Diets.Count).ToList();
            else // rating
                sortNeeded = sortNeeded.OrderByDescending(z => z.Diets.Average(t => t.Rating)).ToList();

            return GetPaginatedDiets(pageNumber, sortNeeded);
        }

        public List<Diet> SearchDiets(string text, Int64 pageNumber)
        {
            List<Diet> dietPlans = GetAllDiets();
            List<Diet> filteredDiets = new List<Diet>();

            foreach (var diet in dietPlans)
            {
                foreach(var day in diet.Days)
                {
                    if (day.Victuals.Where(z => z.Victual.Name.Contains(text) &&
                    (filteredDiets.Where(t => t.Id.Equals(diet.Id)).Count() == 0)).Count() != 0)
                        filteredDiets.Add(diet);
                }
            } 
            // days

            if (dietPlans.Where(z => z.Name.Contains(text)).Count() != 0)
                filteredDiets.AddRange(dietPlans.Where(z => z.Name.Contains(text)).ToList());
            // name

            if (dietPlans.Where(z => z.Description.Contains(text)).Count() != 0)
                filteredDiets.AddRange(dietPlans.Where(z => z.Description.Contains(text)
                && filteredDiets.Where(t => t.Id.Equals(z.Id)).Count() == 0).ToList());
            // description

            return GetPaginatedDiets(pageNumber, filteredDiets);
        }


        public List<Diet> GetAllDiets()
        {
            return dietRepository.GetAll();
        }

        public Diet GetDiet(Guid? dietId)
        {
            return dietRepository.ReadDiet(dietId);
        }


        public void SetDietToUser(string userId, Guid? dietId)
        {
            HealthyDietUser user = userRepository.ReadUserStatistics(userId);
            Diet diet = GetDiet(dietId);

            UserDiet userDiet = new UserDiet()
            {
                Id = Guid.NewGuid(),
                DietId = diet.Id,
                Diet = diet,
                StatisticsId = user.StatisticsId,
                Statistics = user.Statistics,
                Active = true,
                DateStarted = DateTime.Now,
                Rating = 0
            };

            UserDiet oldDiet = userDietRepository.ReadAll()
                .Where(z => z.Active).SingleOrDefault();

            if(oldDiet != null)
            {
                oldDiet.Active = false;
                oldDiet.DateFinished = DateTime.Now;
                userDietRepository.Update(oldDiet);
            }

            diet.Diets.Add(userDiet);
            user.Statistics.Diets.Add(userDiet);

            userDietRepository.Create(userDiet);
            userRepository.UpdateUser(user);
            dietRepository.UpdateDiet(diet);
        }

        public List<Diet> GetPaginatedDiets(long pageNumber, List<Diet> diets)
        {
            long secondOffset = pageNumber * 9;
            long firstOffset = secondOffset - 9;
            int pageSize = 9;
            long checkOffset = (int)(diets.Count / 9);

            if (checkOffset == 0) // first page check
                pageSize = diets.Count;
            else if (checkOffset == pageNumber) // last page check
            {
                long lastOffset = (int)(diets.Count % firstOffset);
                if (lastOffset < 9)
                    pageSize = (int)lastOffset;
            }

            return diets.GetRange((int)firstOffset, pageSize);
        }
    }
}
