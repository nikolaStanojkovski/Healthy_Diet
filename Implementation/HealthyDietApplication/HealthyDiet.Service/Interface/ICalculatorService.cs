using HealthyDiet.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Interface
{
    public interface ICalculatorService
    {
        public CalorieCounterDTO GetCounterDTO();

        public CalorieCounterDTO GetCounterDTOWithAllUserVictuals(string userId);

        public CalorieCounterDTO GetCounterDTOWithTodayUserVictuals(string userId);
    }
}
