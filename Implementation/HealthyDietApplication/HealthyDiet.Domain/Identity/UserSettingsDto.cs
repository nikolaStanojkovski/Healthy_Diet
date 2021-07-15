using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Identity
{
    public class UserSettingsDto
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public Language Language { get; set; }

        public String ProfilePictureURL { get; set; }

        [Required]
        public Int64 Age { get; set; }
        [Required]
        public Int64 Height { get; set; }
        [Required]
        public Int64 Weight { get; set; }

        public String ArtName { get; set; }
        public String FavouriteFruit { get; set; }
        public String FavouriteVeggie { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        public Statistics Statistics { get; set; }

        public DayWaterIntake CurrentWaterDay { get; set; }
        public ICollection<DayWaterIntake> WeeklyWaterIntake { get; set; }
        public ICollection<DayWaterIntake> MonthlyWaterIntake { get; set; }

        public CommunityInfo CommunityInfo { get; set; }

        public Diet CurrentDiet { get; set; }
        public UserDiet CurrentUserDiet { get; set; }

        public ICollection<Victual> Victuals { get; set; }
        public Day CurrentDay { get; set; }

        public ICollection<HealthyDietUser> Friends { get; set; }
        public ICollection<HealthyDietUser> Suggestions { get; set; }
    }
}
