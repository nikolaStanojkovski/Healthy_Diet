using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Repository.Interface
{
    public interface IUserRepository
    {
        List<HealthyDietUser> GetAll();

        // For one entity

        void CreateUser(HealthyDietUser entity);

        HealthyDietUser ReadUserInformation(string? id);

        HealthyDietUser ReadUserStatistics(string? id);

        HealthyDietUser ReadUserFriends(string? id);

        void UpdateUser(HealthyDietUser entity);

        void DeleteUser(HealthyDietUser entity);
    }
}
