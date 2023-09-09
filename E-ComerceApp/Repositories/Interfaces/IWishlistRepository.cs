using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;

namespace E_CommerceApp.Repositories.Interfaces
{
    public interface IWishlistRepository
    {
        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByUserId(string userId);
        WishlistItem GetWishlistItemByProductId(int wishlistId, int productId);
        WishlistViewModel GetWishlistViewModel(string userId);
        void CreateWishlist(Wishlist wishlist);
        void RemoveWishlistItem(WishlistItem item);
        void AddWishlistItem(WishlistItem item);
        void ClearWishlist(int wishlistId);
    }
}
