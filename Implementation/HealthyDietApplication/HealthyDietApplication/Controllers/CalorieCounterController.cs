using HealthyDiet.Domain.DTO;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthyDietApplication.Controllers
{
    public class CalorieCounterController : Controller
    {
        private readonly UserManager<HealthyDietUser> userManager;

        private readonly ICalculatorService calculatorService;

        public CalorieCounterController(ICalculatorService _calculatorService,
            UserManager<HealthyDietUser> _userManager)
        {
            this.calculatorService = _calculatorService;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            HealthyDietUser user = null;
            if (User.Identity.IsAuthenticated)
                user = await userManager.FindByEmailAsync(User.Identity.Name);

            return View(calculatorService.GetCounterDTO(user));
        }

        public async Task<IActionResult> TakeFromAccountAllTime()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            return View("Index", calculatorService.GetCounterDTOWithAllUserVictuals(user));
        }

        public async Task<IActionResult> TakeFromAccountToday()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            return View("Index", calculatorService.GetCounterDTOWithTodayUserVictuals(user));
        }
    }
}
