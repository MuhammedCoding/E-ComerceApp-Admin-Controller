using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_ComerceApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(IOrderService orderService, ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _cartService = cartService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AllOrders()
        {
            var user = await _userManager.GetUserAsync(User);

            var orders = _orderService.GetOrdersByUserId(user.Id);

            if (orders == null)
            {
                return View("NoOrders");
            }

            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _cartService.GetCart(user.Id);

            var orderViewModel = new OrderViewModel
            {
                UserId = user.Id,
                TotalPrice = cart.TotalPrice,
                OrderItems = new List<OrderItemViewModel>()

        };
            foreach (var item in cart.Items)
            {
                orderViewModel.OrderItems.Add(new OrderItemViewModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductImage = item.ProductImage,
                    ProductName = item.ProductName, 
                });
            }
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                _orderService.MakeOrder(orderViewModel);
                return RedirectToAction("AllOrders" );
            }

            return View(orderViewModel);
        }
    }
}