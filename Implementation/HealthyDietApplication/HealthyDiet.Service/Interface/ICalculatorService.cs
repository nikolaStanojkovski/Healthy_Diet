using HealthyDiet.Domain.DTO;
using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Interface
{
    public interface ICalculatorService
    {
        public CalorieCounterDTO GetCounterDTO(HealthyDietUser user);

        public CalorieCounterDTO GetCounterDTOWithAllUserVictuals(HealthyDietUser user);

        public CalorieCounterDTO GetCounterDTOWithTodayUserVictuals(HealthyDietUser user);
    }
}
