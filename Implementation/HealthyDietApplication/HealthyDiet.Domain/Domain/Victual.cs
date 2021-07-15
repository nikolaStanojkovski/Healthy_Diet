using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain
{
    public class Victual : BaseEntity
    {
        public String Name { get; set; }
        public Int64 NumberCalories { get; set; }
        public VictualType Type { get; set; }

        public virtual ICollection<FoodSample> Victuals { get; set; }
        public virtual ICollection<RecipeVictual> Recipes { get; set; }
        public virtual ICollection<DayVictual> Days { get; set; }
    }
}
