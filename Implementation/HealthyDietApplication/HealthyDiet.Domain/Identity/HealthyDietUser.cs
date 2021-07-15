using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Identity
{
    public class HealthyDietUser : IdentityUser
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public Language Language { get; set; }
        public String ProfilePictureURL { get; set; }

        public Int64 Age { get; set; }
        public Int64 Height { get; set; }
        public Int64 Weight { get; set; }

        public Guid StatisticsId { get; set; }
        public virtual Statistics Statistics { get; set; }

        public Guid CommunityId { get; set; }
        public virtual CommunityInfo CommunityInfo { get; set; }

        public virtual ICollection<FriendUser> Friends { get; set; }
    }
}
