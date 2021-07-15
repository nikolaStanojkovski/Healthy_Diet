﻿using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.DTO;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Service;
using HealthyDiet.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDietApplication.Controllers
{
    public class DietPlansController : Controller
    {
        private readonly UserManager<HealthyDietUser> userManager;

        private readonly IDietPlanService dietPlanService;
        private readonly IVictualService victualService;

        public DietPlansController(IDietPlanService _dietPlanService,
            IVictualService _victualService,
            UserManager<HealthyDietUser> _userManager)
        {
            this.dietPlanService = _dietPlanService;
            this.victualService = _victualService;
            this.userManager = _userManager;
        }

        public IActionResult Index(Int64 pageNumber = 1)
        {
            // DBDataInsertion insertion = new DBDataInsertion(dietPlanService, victualService);
            // insertion.PopulateDatabaseDietPlans();

            List<Diet> allDiets = dietPlanService.GetAllDiets();
            List<Diet> paginatedDiets = dietPlanService.GetPaginatedDiets(pageNumber, allDiets);
            DietPlansDTO model = new DietPlansDTO
            {
                Diets = paginatedDiets,
                DietsSize = allDiets.Count,
                PageNumber = pageNumber
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult FilterDiets(Int64 dietIntensity, Int64 weightLoss, Int64 lengthDays, Int64 noCalories, Int64 pageNumber)
        {
            List<Diet> fileteredDiets = dietPlanService.FilterDiets(dietIntensity, weightLoss, lengthDays, noCalories, pageNumber);
            DietPlansDTO model = new DietPlansDTO
            {
                Diets = fileteredDiets,
                DietsSize = dietPlanService.GetAllDiets().Count,
                PageNumber = pageNumber
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SortDiets(Int64 sortCondition, Int64 pageNumber)
        {
            List<Diet> sortedDiets = dietPlanService.SortDiets(sortCondition, dietPlanService.GetAllDiets(), pageNumber);
            DietPlansDTO model = new DietPlansDTO
            {
                Diets = sortedDiets,
                DietsSize = dietPlanService.GetAllDiets().Count,
                PageNumber = pageNumber
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SearchDiets(string text, Int64 pageNumber)
        {
            List<Diet> searchedDiets = dietPlanService.SearchDiets(text, pageNumber);
            DietPlansDTO model = new DietPlansDTO
            {
                Diets = searchedDiets,
                DietsSize = dietPlanService.GetAllDiets().Count
            };
            return View("Index", model);
        }


        public IActionResult Details(Guid? dietPlanId)
        {
            Diet model = dietPlanService.GetDiet(dietPlanId);

            return View(model);
        }

        public IActionResult ChooseDietForUser(Guid? dietPlanId)
        {
            var user = userManager.FindByEmailAsync(User.Identity.Name).Result;

            dietPlanService.SetDietToUser(user.Id, dietPlanId);

            return RedirectToAction("Index", "DietPlans");
        }
    }
}
