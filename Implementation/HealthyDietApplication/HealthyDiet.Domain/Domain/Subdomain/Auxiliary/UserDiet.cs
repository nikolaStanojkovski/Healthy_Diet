using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain.Auxiliary
{
    public class UserDiet : BaseEntity
    {
        public Guid DietId { get; set; }
        public Diet Diet { get; set; }

        public Guid StatisticsId { get; set; }
        public Statistics Statistics { get; set; }

        public Boolean Active { get; set; } // Is the diet active right now
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }

        [Range(1, 5)]
        public Int64 Rating { get; set; }
        public Int64 DaysCompleted { get; set; }
    }
}
