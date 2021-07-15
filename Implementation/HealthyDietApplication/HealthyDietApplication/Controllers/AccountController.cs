using HealthyDiet.Domain.Domain;
using HealthyDiet.Domain.Identity;
using HealthyDiet.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthyDietApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<HealthyDietUser> userManager;
        private readonly SignInManager<HealthyDietUser> signInManager;

        private readonly IUserService userService;

        // -------------------------------------------
        // ------------LOGIN-REGISTER-----------------
        // -------------------------------------------

        public AccountController(UserManager<HealthyDietUser> _userManager,
            SignInManager<HealthyDietUser> _signInManager,
            IUserService _userService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            userService = _userService;
        }

        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var userEmailCheck = await userManager.FindByEmailAsync(request.Email);
                if (userEmailCheck == null)
                {
                    var user = userService.CreateNewUser(request);
                    var result = await userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists");
                    return View(request);
                }
            }
            return View(request);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }

        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed");
                    return View(model);
                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
                    true, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // -------------------------------------------
        // ------------------OTHER--------------------
        // -------------------------------------------

        // Settings

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var model = userService.GetUserSettings(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SettingsProfilePicture([FromForm(Name = "file")] IFormFile file)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            if(file != null)
            {
                var fileName = user.Id + ".png";

                string pathToUpload = $"{Directory.GetCurrentDirectory()}\\wwwroot\\custom\\img\\profile-pictures\\{fileName}";

                using (FileStream fileStream = System.IO.File.Create(pathToUpload))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

                UserSettingsDto model = new UserSettingsDto
                {
                    ProfilePictureURL = fileName
                };
                userService.UpdateUserPersonalInformation(user, model);
            }

            return RedirectToAction("Settings", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> SettingsPersonalInfo([Bind("Name,Surname,Language,ProfilePictureURL,Age,Height,Weight")] UserSettingsDto model)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            userService.UpdateUserPersonalInformation(user, model);

            return RedirectToAction("Settings", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> SettingsCommunityInfo([Bind("ArtName,FavouriteFruit,FavouriteVeggie")] UserSettingsDto model)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            userService.UpdateUserCommunityInformation(user, model);

            return RedirectToAction("Settings", "Account");
        }

        // Statistics

        [HttpGet]
        public async Task<IActionResult> Statistics()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var model = userService.GetUserStatistics(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StatisticsWaterUpdate(Double waterIntake)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            userService.UpdateUserWaterIntake(user, waterIntake);

            return RedirectToAction("Statistics", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> StatisticsUpdateDiet(Int64 foodQuantity, Guid food)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            userService.UpdateUserVictualIntake(user, foodQuantity, food);

            return RedirectToAction("Statistics", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> StatisticsRateDiet(Int64 rating)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);

            userService.UpdateUserDietRating(user, rating);

            return RedirectToAction("Statistics", "Account");
        }

        // Statistics

        [HttpGet]
        public async Task<IActionResult> Friends()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var model = userService.GetUserFriends(user);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserFriend(string? userId)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            userService.AddFriendToUser(user, userId);

            return RedirectToAction("Friends", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserFriend(string friendId)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            userService.RemoveFriendFromUser(user, friendId);

            return RedirectToAction("Friends", "Account");
        }
    }
}
