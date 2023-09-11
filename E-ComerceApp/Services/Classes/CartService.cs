using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Classes;
using E_CommerceApp.Repositories.Interfaces;

namespace E_ComerceApp.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public CartViewModel GetCart(string userId)
        {
            var cartViewModel = _cartRepository.GetCartViewModel(userId);
            return cartViewModel;
        }
        public bool AddToCart(string userId, int productId, int quantity = 1)
        {
            var product = _productRepository.GetProductById(productId);
            if (product.Count <= 0)
            {
                return false;
            }

            var cart = _cartRepository.GetCartByUserId(userId);
            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null)
            {
                if (cartItem.Quantity + quantity > product.Count)
                {
                    return false;
                }

                _cartRepository.IncreaseCartItemQuantity(cartItem, quantity);
            }
            else
            {
                if (quantity > product.Count)
                {
                    // Return a message to the user indicating that they've reached the maximum stock count
                    return false;
                }

                cartItem = new CartItem
                {
                    CartID = cart.ID,
                    ProductID = productId,
                    Quantity = quantity
                };
                _cartRepository.AddCartItem(cartItem);
            }

            return true;
        }

        public void DecreaseQuantity(string userId, int productId, int quantity = 1)
        {
            var cart = _cartRepository.GetCartByUserId(userId);
            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null && cartItem.Quantity >= quantity)
            {
                _cartRepository.DecreaseCartItemQuantity(cartItem, quantity);
            }
        }

        public bool IncreaseQuantity(string userId, int productId, int quantity = 1)
        {
            var product = _productRepository.GetProductById(productId);
            var cart = _cartRepository.GetCartByUserId(userId);

            var cartItem = _cartRepository.GetCartItemByProductId(cart.ID, productId);

            if (cartItem != null)
            {
                if (cartItem.Quantity + quantity > product.Count)
                {
                    return false;
                }

                _cartRepository.IncreaseCartItemQuantity(cartItem, quantity);
            }

            return true;
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
