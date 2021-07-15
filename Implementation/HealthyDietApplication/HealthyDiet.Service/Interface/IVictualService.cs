using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Interface
{
    public interface IVictualService
    {
        public List<Victual> GetAllVictuals();

        public Victual CreateVictual(string Name, Int64 NumberCalories, VictualType Type);
    }
}
