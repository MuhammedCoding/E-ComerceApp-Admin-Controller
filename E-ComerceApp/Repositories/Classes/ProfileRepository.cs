using E_ComerceApp.Entities;
using E_ComerceApp.Repositories.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace E_ComerceApp.Repositories.Classes
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly E_CommerceEntities _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileRepository(E_CommerceEntities context)
        {
            _context = context;
        }
        public void UpdateProfile(RegisterViewModel profile)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName == profile.UserName);
            if (user != null)
            {
                user.UserName = profile.UserName;
                user.PasswordHash = profile.Password;
                user.Address = profile.Address;
                user.PhoneNumber = profile.PhoneNumber;
            }
            _context.ApplicationUsers.Update(user);
        }
    }
}
