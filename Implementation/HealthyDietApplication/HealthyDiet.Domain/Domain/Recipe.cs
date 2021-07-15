using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain
{
    public class Recipe : BaseEntity
    {
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String Preparation { get; set; }
        public String PictureURL { get; set; }

        public Int64 FeedbackSum { get; set; }
        public Int64 NoFeedbacks { get; set; }

        public Int64 TimesCooked { get; set; }
        public Int64 PreparationTime { get; set; } // Minutes
        public MealType MealType { get; set; }

        public virtual ICollection<RecipeVictual> Victuals { get; set; }
    }
}
