using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

namespace E_ComerceApp.Services.Classes
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public WishlistViewModel GetWishlist(string userId)
        {
            var wishlistViewModel = _wishlistRepository.GetWishlistViewModel(userId);
            return wishlistViewModel;
        }
        public void AddToWishlist(string userId, int productId)
        {
            var wishlist = _wishlistRepository.GetWishlistByUserId(userId);

            var wishlistItem = _wishlistRepository.GetWishlistItemByProductId(wishlist.ID, productId);


            if (wishlistItem == null)
            {
                wishlistItem = new WishlistItem
                {
                    WishlistID = wishlist.ID,
                    ProductID = productId,
                };

                _wishlistRepository.AddWishlistItem(wishlistItem);
            }
        }

       
        public void RemoveFromWishlist(string userId, int productId)
        {
            var wishlist = _wishlistRepository.GetWishlistByUserId(userId);

            var wishlistItem = _wishlistRepository.GetWishlistItemByProductId(wishlist.ID, productId);

            if (wishlistItem != null)
            {
                _wishlistRepository.RemoveWishlistItem(wishlistItem);
            }
        }
        public void ClearWishlist(int wishlistId)
        {
            _wishlistRepository.ClearWishlist(wishlistId);
        }

    }
}
