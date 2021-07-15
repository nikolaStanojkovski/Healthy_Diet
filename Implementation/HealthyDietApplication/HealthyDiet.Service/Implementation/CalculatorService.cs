using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.DTO;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Implementation
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IRepository<Victual> victualRepository;
        private readonly IUserRepository userRepository;

        public CalculatorService(IRepository<Victual> _victualRepository,
            IUserRepository _userRepository)
        {
            this.victualRepository = _victualRepository;
            this.userRepository = _userRepository;
        }

        public CalorieCounterDTO GetCounterDTO()
        {
            List<Victual> allVictuals = victualRepository.ReadAll();
            List<FoodSample> userVictuals = new List<FoodSample>();

            CalorieCounterDTO model = new CalorieCounterDTO()
            {
                AllVictuals = allVictuals,
                UserVictuals = userVictuals
            };

            return model;
        }

        public CalorieCounterDTO GetCounterDTOWithAllUserVictuals(string userId)
        {
            var user = userRepository.ReadUserStatistics(userId);

            List<Victual> allVictuals = victualRepository.ReadAll();
            List<FoodSample> userVictuals = user.Statistics.Victuals.ToList();

            CalorieCounterDTO model = new CalorieCounterDTO()
            {
                AllVictuals = allVictuals,
                UserVictuals = userVictuals
            };

            return model;
        }

        public CalorieCounterDTO GetCounterDTOWithTodayUserVictuals(string userId)
        {
            var user = userRepository.ReadUserStatistics(userId);

            List<Victual> allVictuals = victualRepository.ReadAll();
            List<FoodSample> userVictuals = user.Statistics
                .Victuals.Where(z => z.Date.DayOfYear.Equals(DateTime.Now.DayOfYear)).ToList();

            CalorieCounterDTO model = new CalorieCounterDTO()
            {
                AllVictuals = allVictuals,
                UserVictuals = userVictuals
            };

            return model;
        }
    }
}
