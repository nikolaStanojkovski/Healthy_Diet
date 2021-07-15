using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain
{
    public class DayWaterIntake : BaseEntity
    {
        public DateTime Date { get; set; }
        public Double Quantity { get; set; } // Liters
        public Double RequiredQuantity { get; set; }

        public Guid StatisticsId { get; set; }
        public virtual Statistics Statistics { get; set; }
    }
}
