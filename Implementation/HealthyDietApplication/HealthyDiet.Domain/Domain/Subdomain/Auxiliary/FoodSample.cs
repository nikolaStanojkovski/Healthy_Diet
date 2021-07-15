using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain
{
    public class FoodSample : BaseEntity
    {
        public Int64 Quantity { get; set; }
        public DateTime Date { get; set; }

        public Guid VictualId { get; set; }
        public virtual Victual Victual { get; set; }

        public Guid StatisticsId { get; set; }
        public virtual Statistics Statistics { get; set; }
    }
}
