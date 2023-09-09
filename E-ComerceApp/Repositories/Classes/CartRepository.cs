using E_ComerceApp.Entities;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Repositories.Classes
{
    public class CartRepository : ICartRepository
    {
        private readonly E_CommerceEntities _context;

        public CartRepository(E_CommerceEntities context)
        {
            _context = context;
        }
        public Cart GetCartById(int id)
        {
            return _context.Carts.Find(id);
        }

        public CartViewModel GetCartViewModel(string userId)
        {
            var cart = _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ApplicationUserId == userId);

            if (cart == null)
            {
                return null;
            }

            var cartViewModel = new CartViewModel
            {
                CartId = cart.ID,
                UserId = cart.ApplicationUserId,
                TotalPrice = cart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price)
            };

            foreach (var cartItem in cart.CartItems)
            {
                var cartItemViewModel = new CartItemViewModel
                {
                    ProductId = cartItem.Product.ID,
                    ProductName = cartItem.Product.Name,
                    ProductImage = cartItem.Product.ImageUrl,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Product.Price
                };
                cartViewModel.Items.Add(cartItemViewModel);
            }

            return cartViewModel;
        }
        public Cart GetCartByUserId(string userId)
        {
            return _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.ApplicationUserId == userId);
        }

        public CartItem GetCartItemByProductId(int cartId, int productId)
        {
            return _context.CartItems.FirstOrDefault(ci => ci.CartID == cartId && ci.ProductID == productId);
        }

        public void CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void AddCartItem(CartItem item)
        {
            _context.CartItems.Add(item);
            _context.SaveChanges();
        }

        public void RemoveCartItem(CartItem item)
        {
            _context.CartItems.Remove(item);
            _context.SaveChanges();
        }

        public void IncreaseCartItemQuantity(CartItem item, int quantity)
        {
            item.Quantity += quantity;
            _context.SaveChanges();
        }

        public void DecreaseCartItemQuantity(CartItem item, int quantity)
        {
            item.Quantity -= quantity;
            if (item.Quantity <= 0)
            {
                _context.CartItems.Remove(item);
            }
            _context.SaveChanges();
        }
        public void ClearCart(int cartId)
        {
            var cartItems = _context.CartItems.Where(c => c.CartID == cartId);
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }
    }
}

