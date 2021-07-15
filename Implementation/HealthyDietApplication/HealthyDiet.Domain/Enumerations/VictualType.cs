using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Enumerations
{
    public enum VictualType
    {
        [Display(Name = "Food")]
        FOOD,
        [Display(Name = "Drink")]
        DRINK,
        [Display(Name = "Water")]
        WATER
    }
}
