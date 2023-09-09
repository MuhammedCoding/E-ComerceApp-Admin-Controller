﻿using E_ComerceApp.Services.Interfaces;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_ComerceApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _cartService.GetCart(user.Id);
            return View(model);
        }
        public async Task<IActionResult> AddToCart(int productId, string controllerName)
        {
            var user = await _userManager.GetUserAsync(User);

            _cartService.AddToCart(user.Id, productId);

            return RedirectToAction("Index",controllerName);
        }
        public async Task<IActionResult> DecreaseQuantity(int productid)
        {
            var user = await _userManager.GetUserAsync(User);

            _cartService.DecreaseQuantity(user.Id, productid);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> IncreaseQuantity(int productid)
        {
            var user = await _userManager.GetUserAsync(User);

            _cartService.IncreaseQuantity(user.Id, productid);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);

            _cartService.RemoveFromCart(user.Id, productId);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
            return RedirectToAction("Index");
        }
    }
}
