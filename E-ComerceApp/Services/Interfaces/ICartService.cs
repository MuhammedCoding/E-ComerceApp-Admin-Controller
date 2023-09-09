using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Classes;
using E_CommerceApp.Repositories.Interfaces;

namespace E_ComerceApp.Services.Interfaces
{
    public interface ICartService { 

        void AddToCart(string userId, int productId, int quantity = 1);
        void DecreaseQuantity(string userId, int productId, int quantity = 1);
        void IncreaseQuantity(string userId, int productId, int quantity = 1);
        void RemoveFromCart(string userId, int productId);
        CartViewModel GetCart(string userId);
        void ClearCart(int cartId);

    }
}
