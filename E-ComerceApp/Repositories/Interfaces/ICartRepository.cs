using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCartById(int id);
        Cart GetCartByUserId(string userId);
        CartItem GetCartItemByProductId(int cartId, int productId);
        CartViewModel GetCartViewModel(string userId);
        void CreateCart(Cart cart);
        void RemoveCartItem(CartItem item);
        void AddCartItem(CartItem item);
        void DecreaseCartItemQuantity(CartItem item, int quantity);
        void IncreaseCartItemQuantity(CartItem item, int quantity);
        void ClearCart(int cartId);

    }
}
