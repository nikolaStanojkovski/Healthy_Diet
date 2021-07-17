using ExcelDataReader;
using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Repository
{
    public class DBDataInsertion
    {
        private readonly IRepository<Victual> victualRepository;
        private readonly IRepository<RecipeVictual> recipeVictualRepository;
        private readonly IRepository<Day> dayRepository;
        private readonly IRepository<DayVictual> dayVictualRepository;
        private readonly IRecipeRepository recipeRepository;
        private readonly IDietRepository dietRepository;

        public DBDataInsertion(IRecipeRepository _recipeRepository,
            IDietRepository _dietRepository,
            IRepository<Victual> _victualRepository,
            IRepository<RecipeVictual> _recipeVictualRepository,
            IRepository<Day> _dayRepository,
            IRepository<DayVictual> _dayVictualRepository)
        {
            this.recipeRepository = _recipeRepository;
            this.dietRepository = _dietRepository;
            this.victualRepository = _victualRepository;
            this.recipeVictualRepository = _recipeVictualRepository;
            this.dayRepository = _dayRepository;
            this.dayVictualRepository = _dayVictualRepository;
        }

        public void PopualteDatabase()
        {
            string victualsFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\Victuals.xlsx";

            string recipeVictualsFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\RecipeVictuals.xlsx";
            string recipesFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\Recipes.xlsx";

            string dietsFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\Diets.xlsx";
            string daysFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\Days.xlsx";
            string dayVitualsFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\DayVictuals.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Victuals
            using (var stream = System.IO.File.Open(victualsFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool firstRow = true;
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) == null)
                            break;

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }
                        else
                        {
                            var model = new Victual
                            {
                                Id = Guid.Parse(reader.GetValue(0).ToString()),
                                Name = reader.GetValue(1).ToString(),
                                NumberCalories = Int64.Parse(reader.GetValue(2).ToString()),
                                Type = (VictualType)Enum.Parse(typeof(VictualType), reader.GetValue(3).ToString())
                            };

                            victualRepository.Create(model);
                        }
                    }
                }
            }

            // Recipes
            using (var stream = System.IO.File.Open(recipesFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool firstRow = true;
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) == null)
                            break;

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }
                        else
                        {
                            var model = new Recipe
                            {
                                Id = Guid.Parse(reader.GetValue(0).ToString()),
                                Name = reader.GetValue(1).ToString(),
                                ShortDescription = reader.GetValue(2).ToString(),
                                Preparation = reader.GetValue(3).ToString(),
                                PictureURL = reader.GetValue(4).ToString(),
                                FeedbackSum = Int64.Parse(reader.GetValue(5).ToString()),
                                NoFeedbacks = Int64.Parse(reader.GetValue(6).ToString()),
                                TimesCooked = Int64.Parse(reader.GetValue(7).ToString()),
                                PreparationTime = Int64.Parse(reader.GetValue(8).ToString()),
                                MealType = (MealType)Enum.Parse(typeof(MealType), reader.GetValue(9).ToString())
                            };

                            recipeRepository.CreateRecipe(model);
                        }
                    }
                }
            }

            // RecipeVictuals
            using (var stream = System.IO.File.Open(recipeVictualsFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool firstRow = true;
                    while (reader.Read())
                    {
                        if (reader.GetValue(1) == null || reader.GetValue(1).Equals(""))
                            break;

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }
                        else
                        {
                            var victualId = Guid.Parse(reader.GetValue(2).ToString());
                            var recipeId = Guid.Parse(reader.GetValue(3).ToString());

                            var victual = victualRepository.Read(victualId);
                            var recipe = recipeRepository.ReadRecipe(recipeId);

                            var model = new RecipeVictual
                            {
                                Id = Guid.NewGuid(),
                                Quantity = Int64.Parse(reader.GetValue(1).ToString()),

                                Victual = victual,
                                VictualId = victualId,

                                Recipe = recipe,
                                RecipeId = recipeId
                            };

                            // recipeRepository.UpdateRecipe(recipe);
                            // victualRepository.Update(victual);
                            recipeVictualRepository.Create(model);
                        }
                    }
                }
            }


            // Diets
            using (var stream = System.IO.File.Open(dietsFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool firstRow = true;
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) == null)
                            break;

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }
                        else
                        {
                            var model = new Diet
                            {
                                Id = Guid.Parse(reader.GetValue(0).ToString()),
                                Name = reader.GetValue(1).ToString(),
                                PictureURL = reader.GetValue(2).ToString(),
                                Description = reader.GetValue(3).ToString(),
                                Intensity = Int64.Parse(reader.GetValue(4).ToString()),
                                WeightLoss - Int64.Parse(reader.GetValue(5).ToString()),
                                LengthDays = Int64.Parse(reader.GetValue(6).ToString())
                            };

                            dietRepository.Create(model);
                        }
                    }
                }
            }

            // Days
            using (var stream = System.IO.File.Open(daysFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool firstRow = true;
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) == null)
                        { // random day fillage
                            List<Diet> unfilledDiets = dietRepository.GetAll()
                                .Where(z => z.Days == null || !z.Days.Any()).ToList();

                            foreach(var diet in unfilledDiets)
                            {
                                for(int i=1;i<=diet.LengthDays;i++)
                                {
                                    Day newDay = new Day
                                    {
                                        Id = Guid.NewGuid(),
                                        Number = i,
                                        DietId = diet.Id,
                                        Diet = diet
                                    };

                                    dayRepository.Create(newDay);
                                }
                            }

                            break;
                        }

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }
                        else
                        {
                            var dietId = Guid.Parse(reader.GetValue(2).ToString());
                            var diet = dietRepository.ReadDiet(dietId);

                            var model = new Day
                            {
                                Id = Guid.Parse(reader.GetValue(0).ToString()),
                                Number = Int64.Parse(reader.GetValue(1).ToString()),
                                DietId = dietId,
                                Diet = diet
                            };

                            dietRepository.Create(model);
                        }
                    }
                }
            }

            // DayVictuals
            using (var stream = System.IO.File.Open(dayVitualsFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool firstRow = true;
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) == null)
                        { // random day victuals fillage
                            List<Day> unfilledDays = dayRepository.GetAll()
                                .Where(z => z.Victuals == null || !z.Victuals.Any()).ToList();

                            foreach (var day in unfilledDays)
                            {
                                Random rnd = new Random();
                                List<Victual> randomVictuals = victualRepository.ReadAll()
                                    .OrderBy(x => rnd.Next()).Take(rnd.Next(1, 10)); // take random victuals with random number

                                foreach(var victual in randomVictuals)
                                {
                                    DayVictual newDayVictual = new DayVictual
                                    {
                                        Id = Guid.NewGuid(),
                                        Quantity = rnd.Next(1, 10),

                                        VictualId = victual.Id,
                                        Victual = victual,
                                        DayId = day.Id,
                                        Day = day
                                    };

                                    dayVictualRepository.Create(newDayVictual);
                                }
                            }

                            break;
                        }

                        if (firstRow)
                        {
                            firstRow = false;
                            continue;
                        }
                        else
                        {
                            var victualId = Guid.Parse(reader.GetValue(1).ToString());
                            var victual = victualRepository.Read(victualId);

                            var dayId = Guid.Parse(reader.GetValue(2).ToString());
                            var day = dayRepository.Read(dayId);

                            var model = new DayVictual
                            {
                                Id = Guid.NewGuid(),
                                Quantity = Int64.Parse(reader.GetValue(3).ToString()),

                                VictualId = victualId,
                                Victual = victual,
                                DayId = dayId,
                                Day = day
                            };

                            dayVictualRepository.Create(model);
                        }
                    }
                }
            }
        }
    }
}
