using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_ComerceApp.Services.Classes
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICartRepository _cartRepository;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICartRepository cartRepository,
            IWishlistRepository wishlistRepository,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartRepository = cartRepository;
            _wishlistRepository = wishlistRepository;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = model.UserName;
            user.PasswordHash = model.Password;
            user.Address = model.Address;
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            if (result.Succeeded)
            {
                // Assign 'Customer' role to the user
                await _userManager.AddToRoleAsync(user, "Customer");

                // Create a cart and wishlist for the user
                _cartRepository.CreateCart(new Cart { ApplicationUser = user });
                _wishlistRepository.CreateWishlist(new Wishlist { ApplicationUser = user });
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<(SignInResult result, string role)> LoginAsync(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            string role = null;
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            }

            return (result, role);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
