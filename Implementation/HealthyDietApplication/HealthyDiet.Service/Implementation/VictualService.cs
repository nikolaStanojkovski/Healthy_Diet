using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Implementation
{
    public class VictualService : IVictualService
    {
        private readonly IRepository<Victual> victualRepository;

        public VictualService(IRepository<Victual> _victualRepository)
        {
            this.victualRepository = _victualRepository;
        }

        public Victual CreateVictual(string Name, long NumberCalories, VictualType Type)
        {
            Victual victual = new Victual()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                NumberCalories = NumberCalories,
                Type = Type
            };

            victualRepository.Create(victual);

            return victual;
        }

        public List<Victual> GetAllVictuals()
        {
            return victualRepository.ReadAll();
        }
    }
}
