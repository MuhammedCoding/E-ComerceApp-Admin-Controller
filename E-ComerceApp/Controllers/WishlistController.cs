using E_ComerceApp.Services.Classes;
using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_ComerceApp.Controllers
{
    public class WishlistController : Controller
    {
        private IWishlistService _wishlistService;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistController(IWishlistService wishlistService, UserManager<ApplicationUser> userManager) {
            
            _wishlistService = wishlistService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _wishlistService.GetWishlist(user.Id);
            return View(model);
        }
        public async Task<IActionResult> RemoveFromWishlist(int productId)
        {
            var user = await _userManager.GetUserAsync(User);

            _wishlistService.RemoveFromWishlist(user.Id, productId);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ClearWishlist(int wishlistId)
        {
            _wishlistService.ClearWishlist(wishlistId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddToWishlist(int productId ,string controllerName)
        {
            var user = await _userManager.GetUserAsync(User);

            _wishlistService.AddToWishlist(user.Id, productId);

            return RedirectToAction("Index", controllerName);
        }
    }
}
