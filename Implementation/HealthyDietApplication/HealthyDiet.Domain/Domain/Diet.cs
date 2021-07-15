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
    public class Diet : BaseEntity
    {
        public String Name { get; set; }
        public String PictureURL { get; set; }
        public String Description { get; set; }

        public Double Intensity { get; set; }
        public Int64 WeightLoss { get; set; } // Kilograms
        public Int64 LengthDays { get; set; }

        public virtual ICollection<Day> Days { get; set; }
        public virtual ICollection<UserDiet> Diets { get; set; }
    }
}
