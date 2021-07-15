using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain
{
    public class RecipeVictual : BaseEntity
    {
        public Int64 Quantity { get; set; }

        public Guid VictualId { get; set; }
        public virtual Victual Victual { get; set; }

        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
