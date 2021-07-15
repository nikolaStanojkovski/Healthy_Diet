using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Domain.Subdomain;
using HealthyDiet.Domain.Domain.Subdomain.Auxiliary;
using HealthyDiet.Domain.Enumerations;
using HealthyDiet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyDiet.Service
{
    public class DBDataInsertion
    {
        private readonly IDietPlanService dietPlanService;
        private readonly IVictualService victualService;
        private readonly IRecipeService recipeService;

        public DBDataInsertion(IDietPlanService _dietPlanService,
            IVictualService _victualService)
        {
            this.dietPlanService = _dietPlanService;
            this.victualService = _victualService;
        }

        public DBDataInsertion(IRecipeService _recipeService,
            IVictualService _victualService)
        {
            this.recipeService = _recipeService;
            this.victualService = _victualService;
        }

        public void PopulateDatabaseDietPlans()
        {
            List<Victual> victuals = new List<Victual>()
            {
                victualService.CreateVictual("Tomato", 30, VictualType.FOOD),
                victualService.CreateVictual("Potato", 50, VictualType.FOOD),
                victualService.CreateVictual("Strawberry", 20, VictualType.FOOD),
                victualService.CreateVictual("Wine", 150, VictualType.DRINK),
                victualService.CreateVictual("Zink", 10, VictualType.DRINK),
                victualService.CreateVictual("Spinach", 200, VictualType.FOOD),
            };

            List<Day> daysFirst = new List<Day>()
            {
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 1
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 2
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 3
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 4
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 5
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 6
                },
            };
            List<List<DayVictual>> victualsFirstDay = new List<List<DayVictual>>()
            {
                new List<DayVictual>()
                {
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysFirst.ElementAt(0),
                        DayId = daysFirst.ElementAt(0).Id,
                        Victual = victuals.ElementAt(0),
                        VictualId = victuals.ElementAt(0).Id,
                        Quantity = 2
                    },
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysFirst.ElementAt(0),
                        DayId = daysFirst.ElementAt(0).Id,
                        Victual = victuals.ElementAt(1),
                        VictualId = victuals.ElementAt(1).Id,
                        Quantity = 4
                    },
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysFirst.ElementAt(0),
                        DayId = daysFirst.ElementAt(0).Id,
                        Victual = victuals.ElementAt(2),
                        VictualId = victuals.ElementAt(2).Id,
                        Quantity = 3
                    },
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysFirst.ElementAt(0),
                        DayId = daysFirst.ElementAt(0).Id,
                        Victual = victuals.ElementAt(3),
                        VictualId = victuals.ElementAt(3).Id,
                        Quantity = 6
                    },
                }, 
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(1),
                    DayId = daysFirst.ElementAt(1).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(1),
                    DayId = daysFirst.ElementAt(1).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(1),
                    DayId = daysFirst.ElementAt(1).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(1),
                    DayId = daysFirst.ElementAt(1).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 6
                },
            }, 
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(2),
                    DayId = daysFirst.ElementAt(2).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(2),
                    DayId = daysFirst.ElementAt(2).Id,
                    Victual = victuals.ElementAt(0),
                    VictualId = victuals.ElementAt(0).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(2),
                    DayId = daysFirst.ElementAt(2).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(2),
                    DayId = daysFirst.ElementAt(2).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(3),
                    DayId = daysFirst.ElementAt(3).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(3),
                    DayId = daysFirst.ElementAt(3).Id,
                    Victual = victuals.ElementAt(0),
                    VictualId = victuals.ElementAt(0).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(3),
                    DayId = daysFirst.ElementAt(3).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(3),
                    DayId = daysFirst.ElementAt(3).Id,
                    Victual = victuals.ElementAt(5),
                    VictualId = victuals.ElementAt(5).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(4),
                    DayId = daysFirst.ElementAt(4).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(4),
                    DayId = daysFirst.ElementAt(4).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(4),
                    DayId = daysFirst.ElementAt(4).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(4),
                    DayId = daysFirst.ElementAt(4).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(5),
                    DayId = daysFirst.ElementAt(5).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(5),
                    DayId = daysFirst.ElementAt(5).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(5),
                    DayId = daysFirst.ElementAt(5).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysFirst.ElementAt(5),
                    DayId = daysFirst.ElementAt(5).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 6
                },
            }
            };
            for(int i=0;i<6;i++)
            {
                daysFirst.ElementAt(i).Victuals = victualsFirstDay.ElementAt(i);
            }

            List<Day> daysSecond = new List<Day>()
            {
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 1
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 2
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 3
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 4
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 5
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Number = 6
                },
            };
            List<List<DayVictual>> victualsSecondDay = new List<List<DayVictual>>()
            {
                new List<DayVictual>()
                {
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysSecond.ElementAt(0),
                        DayId = daysSecond.ElementAt(0).Id,
                        Victual = victuals.ElementAt(0),
                        VictualId = victuals.ElementAt(0).Id,
                        Quantity = 2
                    },
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysSecond.ElementAt(0),
                        DayId = daysSecond.ElementAt(0).Id,
                        Victual = victuals.ElementAt(1),
                        VictualId = victuals.ElementAt(1).Id,
                        Quantity = 4
                    },
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysSecond.ElementAt(0),
                        DayId = daysSecond.ElementAt(0).Id,
                        Victual = victuals.ElementAt(2),
                        VictualId = victuals.ElementAt(2).Id,
                        Quantity = 3
                    },
                    new DayVictual()
                    {
                        Id = Guid.NewGuid(),
                        Day = daysSecond.ElementAt(0),
                        DayId = daysSecond.ElementAt(0).Id,
                        Victual = victuals.ElementAt(3),
                        VictualId = victuals.ElementAt(3).Id,
                        Quantity = 6
                    },
                },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(1),
                    DayId = daysSecond.ElementAt(1).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(1),
                    DayId = daysSecond.ElementAt(1).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(1),
                    DayId = daysSecond.ElementAt(1).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(1),
                    DayId = daysSecond.ElementAt(1).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(2),
                    DayId = daysSecond.ElementAt(2).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(2),
                    DayId = daysSecond.ElementAt(2).Id,
                    Victual = victuals.ElementAt(0),
                    VictualId = victuals.ElementAt(0).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(2),
                    DayId = daysSecond.ElementAt(2).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(2),
                    DayId = daysSecond.ElementAt(2).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(3),
                    DayId = daysSecond.ElementAt(3).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(3),
                    DayId = daysSecond.ElementAt(3).Id,
                    Victual = victuals.ElementAt(0),
                    VictualId = victuals.ElementAt(0).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(3),
                    DayId = daysSecond.ElementAt(3).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(3),
                    DayId = daysSecond.ElementAt(3).Id,
                    Victual = victuals.ElementAt(5),
                    VictualId = victuals.ElementAt(5).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(4),
                    DayId = daysSecond.ElementAt(4).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(4),
                    DayId = daysSecond.ElementAt(4).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(4),
                    DayId = daysSecond.ElementAt(4).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(4),
                    DayId = daysSecond.ElementAt(4).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 6
                },
            },
                new List<DayVictual>()
            {
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(5),
                    DayId = daysSecond.ElementAt(5).Id,
                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id,
                    Quantity = 2
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(5),
                    DayId = daysSecond.ElementAt(5).Id,
                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id,
                    Quantity = 4
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(5),
                    DayId = daysSecond.ElementAt(5).Id,
                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id,
                    Quantity = 3
                },
                new DayVictual()
                {
                    Id = Guid.NewGuid(),
                    Day = daysSecond.ElementAt(5),
                    DayId = daysSecond.ElementAt(5).Id,
                    Victual = victuals.ElementAt(4),
                    VictualId = victuals.ElementAt(4).Id,
                    Quantity = 6
                },
            }
            };
            for (int i = 0; i < 6; i++)
            {
                daysSecond.ElementAt(i).Victuals = victualsSecondDay.ElementAt(i);
            }

            dietPlanService.CreateDiet("Vegan Diet", "Veganism is the practice of abstaining from the use of animal products, particularly in diet, and an associated philosophy that rejects the commodity status of animals.", "data:image/jpeg;base64,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", 90, 15, 7, daysFirst);
            dietPlanService.CreateDiet("Vegetarian Diet", "To get the most out of a vegetarian diet, choose a variety of healthy plant-based foods, such as whole fruits and vegetables, legumes and nuts, and whole grains.", "data:image/jpeg;base64,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", 80, 20, 7, daysSecond);
            /* dietPlanService.CreateDiet("Fasting Diet", 30, 5, 7, daysFourth);
            dietPlanService.CreateDiet("Carnivore Diet", 20, 3, 7, daysFifth);
            dietPlanService.CreateDiet("Low-Calorie Diet", 70, 10, 7, daysSix);
            dietPlanService.CreateDiet("Low-Carb Diet", 50, 8, 7, daysSeven); */
        }

        public void PopulateDatabaseRecipes()
        {
            List<Victual> victuals = new List<Victual>()
            {
                victualService.CreateVictual("Cheese", 130, VictualType.FOOD),
                victualService.CreateVictual("Milk", 150, VictualType.FOOD),
                victualService.CreateVictual("Bluberry", 120, VictualType.FOOD),
                victualService.CreateVictual("Pork", 450, VictualType.FOOD),
                victualService.CreateVictual("Beans", 110, VictualType.FOOD),
                victualService.CreateVictual("Tuna", 200, VictualType.FOOD),
            };

            List<RecipeVictual> firstRecipeVictuals = new List<RecipeVictual>()
            {
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 4,

                    Victual = victuals.ElementAt(0),
                    VictualId = victuals.ElementAt(0).Id
                },
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 6,

                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id
                },
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 2,

                    Victual = victuals.ElementAt(2),
                    VictualId = victuals.ElementAt(2).Id
                },
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 3,

                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id
                }
            };
            Recipe firstRecipe = new Recipe()
            {
                Name = "Bean Soup",
                ShortDescription = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                Preparation = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PictureURL = "data:image/jpeg;base64,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",

                NoFeedbacks = 0,
                FeedbackSum = 0,

                TimesCooked = 0,
                PreparationTime = 40,
                MealType = MealType.LUNCH,
                Victuals = firstRecipeVictuals
            };
            foreach(var recipeVictual in firstRecipeVictuals)
            {
                recipeVictual.Recipe = firstRecipe;
                recipeVictual.RecipeId = firstRecipe.Id;
            }
            recipeService.CreateRecipe(firstRecipe);

            List<RecipeVictual> secondRecipeVictuals = new List<RecipeVictual>()
            {
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 7,

                    Victual = victuals.ElementAt(5),
                    VictualId = victuals.ElementAt(5).Id
                },
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,

                    Victual = victuals.ElementAt(1),
                    VictualId = victuals.ElementAt(1).Id
                },
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 4,

                    Victual = victuals.ElementAt(3),
                    VictualId = victuals.ElementAt(3).Id
                },
                new RecipeVictual()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 8,

                    Victual = victuals.ElementAt(0),
                    VictualId = victuals.ElementAt(0).Id
                }
            };
            Recipe secondRecipe = new Recipe()
            {
                Name = "Burito Bowl",
                ShortDescription = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                Preparation = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PictureURL = "data:image/jpeg;base64,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",

                NoFeedbacks = 0,
                FeedbackSum = 0,

                TimesCooked = 0,
                PreparationTime = 90,
                MealType = MealType.LUNCH,
                Victuals = secondRecipeVictuals
            };
            foreach (var recipeVictual in secondRecipeVictuals)
            {
                recipeVictual.Recipe = secondRecipe;
                recipeVictual.RecipeId = secondRecipe.Id;
            }
            recipeService.CreateRecipe(secondRecipe);
        }
    }
}
