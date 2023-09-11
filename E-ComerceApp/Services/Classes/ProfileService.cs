using E_ComerceApp.Repositories.Interfaces;
using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Identity;

namespace E_ComerceApp.Services.Classes
{

    public class ProfileService : IProfileSevice
    {
        private readonly IProfileRepository _profileRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public ProfileService(IProfileRepository profileRepository, UserManager<ApplicationUser> userManager)
        {
            _profileRepository = profileRepository;
            _userManager = userManager;
        }

        public async Task<bool> UpdateProfile(RegisterViewModel profile)
        {
            var user = await _userManager.FindByIdAsync(profile.Id);
            
            var passwordMatch = await _userManager.CheckPasswordAsync(user, profile.Password);
            if (!passwordMatch)
                return false;
            
            user.UserName = profile.UserName;
            user.Address = profile.Address;
            user.PhoneNumber = profile.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
        public async Task<RegisterViewModel> GetProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var profile = new RegisterViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
            };

            return profile;
        }
    }


}

