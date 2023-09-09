using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Classes;
using E_CommerceApp.Repositories.Interfaces;

namespace E_ComerceApp.Services.Interfaces
{
    public interface IWishlistService { 

        void AddToWishlist(string userId, int productId);
        void RemoveFromWishlist(string userId, int productId);
        WishlistViewModel GetWishlist(string userId);
        void ClearWishlist(int wishlistId);

    }
}
