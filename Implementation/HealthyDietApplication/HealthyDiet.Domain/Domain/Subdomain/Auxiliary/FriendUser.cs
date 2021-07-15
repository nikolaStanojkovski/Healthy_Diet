using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain.Subdomain.Auxiliary
{
    public class FriendUser : BaseEntity
    {
        public string UserId { get; set; }
        public HealthyDietUser User { get; set; }

        public string FriendId { get; set; }
        public HealthyDietUser Friend { get; set; }
    }
}
