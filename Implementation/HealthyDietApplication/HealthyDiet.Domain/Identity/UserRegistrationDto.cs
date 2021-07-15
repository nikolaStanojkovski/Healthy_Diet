using HealthyDiet.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Identity
{
    public class UserRegistrationDto
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public Language Language { get; set; }

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

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Compare("Password", ErrorMessage = "The password and Confirm password do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
