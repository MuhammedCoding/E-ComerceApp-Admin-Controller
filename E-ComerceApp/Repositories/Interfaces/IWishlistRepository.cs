using E_CommerceApp.Models;

namespace E_CommerceApp.Repositories.Interfaces
{
    public interface IWishlistRepository
    {
        Wishlist GetWishlistById(int id);
        void CreateWishlist(Wishlist wishlist);
        void UpdateWishlist(Wishlist wishlist);
        void DeleteWishlist(int id);
    }
}
