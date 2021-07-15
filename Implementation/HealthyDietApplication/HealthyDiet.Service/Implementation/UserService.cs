using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Repository.Interface;
using HealthyDiet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IDietRepository dietRepository;
        private readonly IRepository<UserDiet> userDietRepository;
        private readonly IRepository<FoodSample> foodSampleRepository;
        private readonly IRepository<Victual> victualRepository;
        private readonly IRepository<CommunityInfo> communityRepository;
        private readonly IRepository<DayWaterIntake> waterIntakeRepository;
        private readonly IRepository<Statistics> statisticsRepository;
        private readonly IRepository<FriendUser> friendRepository;

        public UserService(IUserRepository _userRepository,
            IDietRepository _dietRepository,
            IRepository<CommunityInfo> _communityRepository,
            IRepository<DayWaterIntake> _waterIntakeRepository,
            IRepository<Statistics> _statisticsRepository,
            IRepository<FriendUser> _friendRepository,
            IRepository<UserDiet> _userDietRepository,
            IRepository<FoodSample> _foodSampleRepository,
            IRepository<Victual> _victualRepository)
        {
            this.userRepository = _userRepository;
            this.dietRepository = _dietRepository;
            this.communityRepository = _communityRepository;
            this.waterIntakeRepository = _waterIntakeRepository;
            this.statisticsRepository = _statisticsRepository;
            this.friendRepository = _friendRepository;
            this.userDietRepository = _userDietRepository;
            this.foodSampleRepository = _foodSampleRepository;
            this.victualRepository = _victualRepository;
        }

        public UserSettingsDto GetUserSettings(HealthyDietUser user)
        {
            user = userRepository.ReadUserInformation(user.Id);

            UserSettingsDto model = new UserSettingsDto
            {
                Email = user.Email,
                ProfilePictureURL = user.ProfilePictureURL,

                Name = user.Name,
                Surname = user.Surname,
                Language = user.Language,

                Age = user.Age,
                Height = user.Height,
                Weight = user.Weight,

                ArtName = user.CommunityInfo.ArtName,
                FavouriteFruit = user.CommunityInfo.FavouriteFruit,
                FavouriteVeggie = user.CommunityInfo.FavouriteVeggie,

                Statistics = null,
                CommunityInfo = user.CommunityInfo,
                Friends = null
            };

            return model;
        }

        public UserSettingsDto GetUserStatistics(HealthyDietUser user)
        {
            user = userRepository.ReadUserStatistics(user.Id);

            var currentUserDiet = userDietRepository.ReadAll().Where(z => z.StatisticsId
                    .Equals(user.StatisticsId) && z.Active).SingleOrDefault();

            Diet currentDiet = null;
            Day currentDay = null;
            if (currentUserDiet != null)
            {
                int activeLength = (DateTime.Now.DayOfYear - currentUserDiet.DateStarted.DayOfYear) + 1;
                currentDiet = dietRepository.ReadDiet(currentUserDiet.DietId);
                currentDay = currentDiet.Days.Where(z => z.Number == activeLength)
                    .SingleOrDefault();
            }

            ICollection<Victual> victuals = victualRepository.ReadAll();

            var waterIntakeDay = CheckNewWaterIntakeDay(user);
            var weeklyWater = GetWeeklyWaterIntake(user, waterIntakeDay);
            var monthlyWater = GetMonthlyWaterIntake(user, waterIntakeDay);

            UserSettingsDto model = new UserSettingsDto
            {
                Email = user.Email,
                ProfilePictureURL = user.ProfilePictureURL,

                Name = user.Name,
                Surname = user.Surname,
                Language = user.Language,

                Age = user.Age,
                Height = user.Height,
                Weight = user.Weight,

                ArtName = user.CommunityInfo.ArtName,
                FavouriteFruit = user.CommunityInfo.FavouriteFruit,
                FavouriteVeggie = user.CommunityInfo.FavouriteVeggie,

                Statistics = user.Statistics,

                CurrentWaterDay = waterIntakeDay,
                WeeklyWaterIntake = weeklyWater,
                MonthlyWaterIntake = monthlyWater,

                Victuals = victuals,
                CurrentDay = currentDay,

                CommunityInfo = user.CommunityInfo,
                CurrentDiet = currentDiet,
                CurrentUserDiet = currentUserDiet,
                Friends = null
            };

            CheckCurrentDayCompleted(user, model);

            return model;
        }

        public UserSettingsDto GetUserFriends(HealthyDietUser user)
        {
            user = userRepository.ReadUserFriends(user.Id);

            ICollection<HealthyDietUser> friends = new List<HealthyDietUser>();
            ICollection<HealthyDietUser> suggestions = GetSuggestionFriends(user);
            
            if(user.Friends != null && user.Friends.Count != 0)
            {
                foreach (var friend in user.Friends)
                {
                    HealthyDietUser toAdd = userRepository.ReadUserFriends(friend.FriendId);

                    if (toAdd != null)
                        friends.Add(toAdd);
                }
            }

            UserSettingsDto model = new UserSettingsDto
            {
                Email = user.Email,
                ProfilePictureURL = user.ProfilePictureURL,

                Name = user.Name,
                Surname = user.Surname,
                Language = user.Language,

                Age = user.Age,
                Height = user.Height,
                Weight = user.Weight,

                ArtName = user.CommunityInfo.ArtName,
                FavouriteFruit = user.CommunityInfo.FavouriteFruit,
                FavouriteVeggie = user.CommunityInfo.FavouriteVeggie,

                Statistics = null,
                CommunityInfo = null,

                Friends = friends,
                Suggestions = suggestions
            };

            return model;
        }

        public HealthyDietUser CreateNewUser(UserRegistrationDto request)
        {
            var userStatistics = new Statistics
            {
                Id = Guid.NewGuid()
            };
            var userCommunity = new CommunityInfo
            {
                Id = Guid.NewGuid(),
                ArtName = request.ArtName,
                FavouriteFruit = request.FavouriteFruit,
                FavouriteVeggie = request.FavouriteVeggie,
                Username = request.Email
            };

            var user = new HealthyDietUser
            {
                UserName = request.Email,
                NormalizedUserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ProfilePictureURL = "default-account.png",

                Name = request.Name,
                Surname = request.Surname,
                Language = request.Language,

                Age = request.Age,
                Height = request.Height,
                Weight = request.Weight,

                StatisticsId = userStatistics.Id,
                Statistics = userStatistics,
                CommunityId = userCommunity.Id,
                CommunityInfo = userCommunity,
            };

            userStatistics.UserId = user.Id;
            userStatistics.User = user;
            userCommunity.UserId = user.Id;
            userCommunity.User = user;

            return user;
        }


        private DayWaterIntake CheckNewWaterIntakeDay(HealthyDietUser user)
        {
            bool createNewDay = true;
            DayWaterIntake dayWater = null;

            foreach (DayWaterIntake waterIntake in user.Statistics.WaterIntake)
            {
                if (waterIntake.Date.DayOfYear == DateTime.Now.DayOfYear)
                {
                    createNewDay = false;
                    dayWater = waterIntake;
                    break;
                }  
            }

            if (user.Statistics.WaterIntake.Count == 0 || createNewDay)
            {
                dayWater = new DayWaterIntake
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Quantity = 0,
                    RequiredQuantity = ((user.Weight * 2.205 * 2.0) / 3.0) / 33.814, // Required water intake in litres from kilos
                    Statistics = user.Statistics,
                    StatisticsId = user.Statistics.Id
                };

                user.Statistics.WaterIntake.Add(dayWater);

                waterIntakeRepository.Create(dayWater);
                userRepository.UpdateUser(user);
            }

            return dayWater;
        }

        private bool CheckFoodSample(HealthyDietUser user, Victual victual)
        {
            return foodSampleRepository.ReadAll()
                .Where(z => z.StatisticsId.Equals(user.StatisticsId) 
                && z.VictualId.Equals(victual.Id)).Count() != 0;
        }


        private ICollection<DayWaterIntake> GetWeeklyWaterIntake(HealthyDietUser user, DayWaterIntake dayWaterIntake)
        {
            user = userRepository.ReadUserStatistics(user.Id);
            ICollection<DayWaterIntake> dayWaterIntakes = new List<DayWaterIntake>();
            for(int i=dayWaterIntake.Date.DayOfYear - 6; i <= dayWaterIntake.Date.DayOfYear; i++)
            {
                List<DayWaterIntake> userFiltered = waterIntakeRepository.ReadAll()
                    .Where(z => z.StatisticsId.Equals(user.StatisticsId)).ToList();

                DayWaterIntake dayFiltered = userFiltered.Where(z => z.Date.DayOfYear == i).SingleOrDefault();

                if(dayFiltered != null)
                    dayWaterIntakes.Add(dayFiltered);
            }

            return dayWaterIntakes;
        }

        private ICollection<DayWaterIntake> GetMonthlyWaterIntake(HealthyDietUser user, DayWaterIntake dayWaterIntake)
        {
            user = userRepository.ReadUserStatistics(user.Id);
            ICollection<DayWaterIntake> dayWaterIntakes = new List<DayWaterIntake>();
            for (int i = dayWaterIntake.Date.DayOfYear - 29; i <= dayWaterIntake.Date.DayOfYear; i++)
            {
                List<DayWaterIntake> userFiltered = waterIntakeRepository.ReadAll()
                    .Where(z => z.StatisticsId.Equals(user.StatisticsId)).ToList();

                DayWaterIntake dayFiltered = userFiltered.Where(z => z.Date.DayOfYear == i).SingleOrDefault();

                if (dayFiltered != null)
                    dayWaterIntakes.Add(dayFiltered);
            }

            return dayWaterIntakes;
        }

        private ICollection<HealthyDietUser> GetSuggestionFriends(HealthyDietUser user)
        {
            ICollection<HealthyDietUser> suggestions = new List<HealthyDietUser>();

            if (user.Friends != null && user.Friends.Count != 0)
            {
                foreach (var suggestion in userRepository.GetAll())
                {
                    if (user.Friends.Where(z => z.FriendId.Equals(suggestion.Id)).Count() == 0 &&
                        !suggestion.Id.Equals(user.Id))
                        suggestions.Add(userRepository.ReadUserFriends(suggestion.Id));
                }
            }
            else
            {
                foreach(var suggestion in userRepository.GetAll())
                {
                    if(!suggestion.Id.Equals(user.Id))
                        suggestions.Add(userRepository.ReadUserFriends(suggestion.Id));
                }
            }

            return suggestions.Take(10).ToList(); // max 10 suggestions
        }

        private void CheckCurrentDayCompleted(HealthyDietUser user, UserSettingsDto model)
        {
            var dietDay = model.CurrentDay;
            double noEatenVictual = 0;
            double noTotalVictuals = 0;
            if (dietDay != null && dietDay.Victuals != null && dietDay.Victuals.Count != 0)
            {
                noTotalVictuals = dietDay.Victuals.Count;

                foreach (var victual in dietDay.Victuals)
                {
                    var eaten = model.Statistics.Victuals.Where(z =>
                        z.VictualId.Equals(victual.VictualId)
                        && z.Date.DayOfYear == DateTime.Now.DayOfYear).SingleOrDefault();

                    if (eaten != null && eaten.Quantity >= victual.Quantity)
                        noEatenVictual++;
                }

                var ha = (DateTime.Now.DayOfYear - model.CurrentUserDiet.DateStarted.DayOfYear);

                if (noEatenVictual == noTotalVictuals &&
                    (DateTime.Now.DayOfYear - model.CurrentUserDiet.DateStarted.DayOfYear)
                    >= model.CurrentUserDiet.DaysCompleted)
                {
                    var userDiet = model.CurrentUserDiet;
                    userDiet.DaysCompleted++;

                    if(userDiet.DaysCompleted == model.CurrentDiet.LengthDays)
                    {
                        userDiet.Active = false;
                        userDiet.DateFinished = DateTime.Now;
                    }

                    userDietRepository.Update(userDiet);
                    userRepository.UpdateUser(user);
                }
            }
        }


        public void UpdateUserPersonalInformation(HealthyDietUser user, UserSettingsDto model)
        {
            if(model.Name != null && !model.Name.Equals(""))
                user.Name = model.Name;

            if (model.Surname != null && !model.Surname.Equals(""))
                user.Surname = model.Surname;

            if (model.Language != null)
                user.Language = model.Language;

            if (model.ProfilePictureURL != null && !model.ProfilePictureURL.Equals(""))
                user.ProfilePictureURL = model.ProfilePictureURL;

            if (model.Age != null && !model.Age.Equals("") && !model.Age.Equals(0))
                user.Age = model.Age;

            if (model.Height != null && !model.Height.Equals("") && !model.Height.Equals(0))
                user.Height = model.Height;

            if (model.Weight != null && !model.Weight.Equals("") && !model.Weight.Equals(0))
                user.Weight = model.Weight;

            userRepository.UpdateUser(user);
        }

        public void UpdateUserCommunityInformation(HealthyDietUser user, UserSettingsDto model)
        {
            CommunityInfo community = communityRepository.ReadAll()
                .Where(z => z.UserId.Equals(user.Id)).SingleOrDefault();

            community.ArtName = model.ArtName;
            community.FavouriteFruit = model.FavouriteFruit;
            community.FavouriteVeggie = model.FavouriteVeggie;
            
            user.CommunityId = community.Id;
            user.CommunityInfo = community;
            
            communityRepository.Update(community);
            userRepository.UpdateUser(user);
        }

        public void UpdateUserWaterIntake(HealthyDietUser user, double waterIntake)
        {
            user = userRepository.ReadUserStatistics(user.Id);
            DayWaterIntake day = CheckNewWaterIntakeDay(user);
            day.Quantity += waterIntake;

            waterIntakeRepository.Update(day);
            userRepository.UpdateUser(user);
        }

        public void UpdateUserVictualIntake(HealthyDietUser user, long quantity, Guid victualId)
        {
            user = userRepository.ReadUserStatistics(user.Id);
            var victual = victualRepository.Read(victualId);
            bool exists = CheckFoodSample(user, victual);

            if(exists)
            {
                var foodSample = foodSampleRepository.ReadAll()
                    .Where(z => z.StatisticsId.Equals(user.StatisticsId)
                    && z.VictualId.Equals(victual.Id)).FirstOrDefault();
                foodSample.Quantity += quantity;
                foodSampleRepository.Update(foodSample);
            } else
            {
                FoodSample newSample = new FoodSample()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Quantity = quantity,

                    Statistics = user.Statistics,
                    StatisticsId = user.StatisticsId,
                    Victual = victual,
                    VictualId = victual.Id
                };
                foodSampleRepository.Create(newSample);
                user.Statistics.Victuals.Add(newSample);
            }

            userRepository.UpdateUser(user);
        }

        public void UpdateUserDietRating(HealthyDietUser user, long rating)
        {
            user = userRepository.ReadUserStatistics(user.Id);
            UserDiet dietToRate = userDietRepository.ReadAll()
                .Where(z => z.Active && z.StatisticsId.Equals(user.StatisticsId))
                .FirstOrDefault();

            dietToRate.Rating = rating;

            userDietRepository.Update(dietToRate);
            userRepository.UpdateUser(user);
        }

        public void AddFriendToUser(HealthyDietUser user, string userId)
        {
            user = userRepository.ReadUserFriends(user.Id);
            var secondUser = userRepository.ReadUserFriends(userId);

            FriendUser friend = new FriendUser
            {
                Id = Guid.NewGuid(),
                FriendId = secondUser.Id,
                Friend = secondUser,
            };

            friendRepository.Create(friend);

            user.Friends.Add(friend);

            userRepository.UpdateUser(user);
        }

        public void RemoveFriendFromUser(HealthyDietUser user, string friendId)
        {
            user = userRepository.ReadUserFriends(user.Id);

            var toRemove = friendRepository.ReadAll().Where(z => 
            z.FriendId.Equals(friendId) && z.UserId.Equals(user.Id)).SingleOrDefault();

            user.Friends.Remove(toRemove);

            friendRepository.Delete(toRemove);

            userRepository.UpdateUser(user);
        }
    }
}
