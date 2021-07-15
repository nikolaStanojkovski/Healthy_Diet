using HealthyDiet.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Repository.Interface
{
    public interface IDietRepository
    {
        List<Diet> GetAll();

        // For one entity

        Diet ReadDiet(Guid? dietId);

        Diet CreateDiet(Diet entity);

        void UpdateDiet(Diet entity);
    }
}
