using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Interface
{
    public interface IUserService
    {
        public HealthyDietUser CreateNewUser(UserRegistrationDto request);
        public void UpdateUserPersonalInformation(HealthyDietUser user, UserSettingsDto model);
        public void UpdateUserCommunityInformation(HealthyDietUser user, UserSettingsDto model);

        public void UpdateUserWaterIntake(HealthyDietUser user, Double waterIntake);
        public void UpdateUserVictualIntake(HealthyDietUser user, Int64 quantity, Guid victualId);
        public void UpdateUserDietRating(HealthyDietUser user, Int64 rating);

        public UserSettingsDto GetUserSettings(HealthyDietUser user);
        public UserSettingsDto GetUserStatistics(HealthyDietUser user);
        public UserSettingsDto GetUserFriends(HealthyDietUser user);

        public void AddFriendToUser(HealthyDietUser user, string userId);
        public void RemoveFriendFromUser(HealthyDietUser user, string friendId);
    }
}
