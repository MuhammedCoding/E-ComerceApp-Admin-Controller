using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_ComerceApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileSevice _profileService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(IProfileSevice profileService,UserManager<ApplicationUser> userManager)
        {
            _profileService = profileService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Update()
        {
            var user = await _userManager.GetUserAsync(User);
            var profile = await _profileService.GetProfile(user.Id);
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            try
            {
                bool isUpdateSuccessful = await _profileService.UpdateProfile(registerViewModel);

                if (!isUpdateSuccessful)
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return View(registerViewModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the profile.");
                return View(registerViewModel);
            }

            return RedirectToAction("Index","Customer");
        }
    }
}