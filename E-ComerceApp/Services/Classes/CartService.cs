using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

namespace E_ComerceApp.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public CartViewModel GetCart(string userId)
        {
            var cartViewModel = _cartRepository.GetCartViewModel(userId);
            return cartViewModel;
        }
        public void AddToCart(string userId, int productId, int quantity = 1)
        {
            var cart = _cartRepository.GetCartByUserId(userId);

            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null)
            {
                _cartRepository.IncreaseCartItemQuantity(cartItem, quantity);
            }
            else
            {
                cartItem = new CartItem
                {
                    CartID = cart.ID,
                    ProductID = productId,
                    Quantity = quantity
                };

                _cartRepository.AddCartItem(cartItem);
            }

        }
        public void DecreaseQuantity(string userId, int productId, int quantity = 1)
        {
            var cart = _cartRepository.GetCartByUserId(userId);

            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null)
            {
                _cartRepository.DecreaseCartItemQuantity(cartItem, quantity);
            }
        }
        public void IncreaseQuantity(string userId, int productId, int quantity = 1)
        {
            var cart = _cartRepository.GetCartByUserId(userId);

            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null)
            {
                _cartRepository.IncreaseCartItemQuantity(cartItem, quantity);
            }
        }

        public void RemoveFromCart(string userId, int productId)
        {
            var cart = _cartRepository.GetCartByUserId(userId);

            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null)
            {
                _cartRepository.RemoveCartItem(cartItem);
            }
        }
        public void ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);
        }

    }
}
