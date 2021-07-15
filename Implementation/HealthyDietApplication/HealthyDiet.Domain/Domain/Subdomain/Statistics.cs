using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain
{
    public class Statistics : BaseEntity
    {
        public virtual ICollection<DayWaterIntake> WaterIntake { get; set; }
        public virtual ICollection<FoodSample> Victuals { get; set; }
        public virtual ICollection<UserDiet> Diets { get; set; }

        public string UserId { get; set; }
        public virtual HealthyDietUser User { get; set; }
    }
}
