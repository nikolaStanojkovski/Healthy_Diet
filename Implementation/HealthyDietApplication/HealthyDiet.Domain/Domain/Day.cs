using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain
{
    public class Day : BaseEntity
    {
        public Int64 Number { get; set; }

        public Guid DietId { get; set; }
        public virtual Diet Diet { get; set; }

        public virtual ICollection<DayVictual> Victuals { get; set; }
    }
}
