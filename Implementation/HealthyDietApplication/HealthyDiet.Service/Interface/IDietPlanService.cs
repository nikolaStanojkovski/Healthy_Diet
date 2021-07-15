using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Interface
{
    public interface IDietPlanService
    {
        public List<Diet> GetAllDiets();

        public List<Diet> GetPaginatedDiets(Int64 pageNumber, List<Diet> diets);

        // Filters and sorting

        public List<Diet> FilterDiets(Int64 dietIntensity, Int64 weightLoss, Int64 lengthDays, Int64 noCalories, Int64 pageNumber);

        public List<Diet> SortDiets(Int64 sortCondition, List<Diet> diets, Int64 pageNumber);

        public List<Diet> SearchDiets(string text, Int64 pageNumber);


        public Diet CreateDiet(string Name, string Description, string PictureURL, Double Intensity, Int64 WeightLoss, Int64 LengthDays, ICollection<Day> Days);

        public Diet GetDiet(Guid? dietId);

        public void SetDietToUser(string userId, Guid? dietId);
    }
}
