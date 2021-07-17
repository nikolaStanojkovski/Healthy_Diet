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
        private readonly IRecipeRepository recipeRepository;
        private readonly IDietRepository dietRepository;

        public DBDataInsertion(IRecipeRepository _recipeRepository,
            IDietRepository _dietRepository,
            IRepository<Victual> _victualRepository,
            IRepository<RecipeVictual> _recipeVictualRepository)
        {
            this.recipeRepository = _recipeRepository;
            this.dietRepository = _dietRepository;
            this.victualRepository = _victualRepository;
            this.recipeVictualRepository = _recipeVictualRepository;
        }

        public void PopualteDatabase()
        {
            string victualsFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\Victuals.xlsx";
            string recipeVictualsFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\RecipeVictuals.xlsx";
            string recipesFilePath = $"{Directory.GetCurrentDirectory()}\\Data\\Files\\Recipes.xlsx";

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
        }
    }
}
