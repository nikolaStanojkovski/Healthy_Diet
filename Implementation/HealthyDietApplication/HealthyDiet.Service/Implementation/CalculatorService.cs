using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.DTO;
using HealthyDiet.Domain.Identity;
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

        public CalorieCounterDTO GetCounterDTO(HealthyDietUser user)
        {
            List<Victual> allVictuals = victualRepository.ReadAll();
            List<FoodSample> userVictuals = new List<FoodSample>();

            if(user != null)
                user = userRepository.ReadUserInformation(user.Id);

            CalorieCounterDTO model = new CalorieCounterDTO()
            {
                AllVictuals = allVictuals,
                UserVictuals = userVictuals,
                User = user
            };

            return model;
        }

        public CalorieCounterDTO GetCounterDTOWithAllUserVictuals(HealthyDietUser user)
        {
            user = userRepository.ReadUserStatistics(user.Id);

            List<Victual> allVictuals = victualRepository.ReadAll();
            List<FoodSample> userVictuals = user.Statistics.Victuals.ToList();

            CalorieCounterDTO model = new CalorieCounterDTO()
            {
                AllVictuals = allVictuals,
                UserVictuals = userVictuals,
                User = user
            };

            return model;
        }

        public CalorieCounterDTO GetCounterDTOWithTodayUserVictuals(HealthyDietUser user)
        {
            user = userRepository.ReadUserStatistics(user.Id);

            List<Victual> allVictuals = victualRepository.ReadAll();
            List<FoodSample> userVictuals = user.Statistics
                .Victuals.Where(z => z.Date.DayOfYear.Equals(DateTime.Now.DayOfYear)).ToList();

            CalorieCounterDTO model = new CalorieCounterDTO()
            {
                AllVictuals = allVictuals,
                UserVictuals = userVictuals,
                User = user
            };

            return model;
        }
    }
}
