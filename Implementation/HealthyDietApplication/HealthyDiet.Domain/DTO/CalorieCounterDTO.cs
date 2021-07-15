using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.DTO
{
    public class CalorieCounterDTO
    {
        public List<Victual> AllVictuals { get; set; }
        public List<FoodSample> UserVictuals { get; set; }
    }
}
