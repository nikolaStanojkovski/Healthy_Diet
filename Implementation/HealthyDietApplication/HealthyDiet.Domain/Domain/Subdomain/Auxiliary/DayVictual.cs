using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain.Auxiliary
{
    public class DayVictual : BaseEntity
    {
        public Guid VictualId { get; set; }
        public Victual Victual { get; set; }

        public Guid DayId { get; set; }
        public Day Day { get; set; }

        public Int64 Quantity { get; set; }
    }
}
