using HealthyDiet.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Domain.DTO
{
    public class DietPlansDTO
    {
        public List<Diet> Diets { get; set; }

        public Int64 DietsSize { get; set; }

        public Int64 PageNumber { get; set; }

        public Boolean AreFiltered { get; set; }
        public Boolean AreSorted { get; set; }
        public int SortCondition { get; set; }
    }
}
