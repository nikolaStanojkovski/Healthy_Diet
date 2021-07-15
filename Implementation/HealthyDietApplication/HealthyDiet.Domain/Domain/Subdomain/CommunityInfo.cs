using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.Domain
{
    public class CommunityInfo : BaseEntity
    {
        public String ArtName { get; set; }
        public String FavouriteFruit { get; set; }
        public String FavouriteVeggie { get; set; }
        public String Username { get; set; }

        public string UserId { get; set; }
        public virtual HealthyDietUser User { get; set; }
    }
}
