using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Enumerations
{
    public enum Language
    {
        [Display(Name = "English")]
        ENGLISH,
        [Display(Name = "Macedonian")]
        MACEDONIAN
    }
}
