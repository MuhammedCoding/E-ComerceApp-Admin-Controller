using E_ComerceApp.Entities;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Repositories.Classes
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly E_CommerceEntities _context;
        public WishlistRepository(E_CommerceEntities context)
        {
            _context = context;
        }
        public Wishlist GetWishlistById(int id)
        {
            return _context.Wishlists.Find(id);
        }
        public WishlistViewModel GetWishlistViewModel(string userId)
        {
            var wishlist = _context.Wishlists
                .Include(c => c.WishlistItems)
                    .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.ApplicationUserId == userId);

            if (wishlist == null)
            {
                return null;
            }

            var wishlistViewModel = new WishlistViewModel
            {
                WishlistId = wishlist.ID,
                UserId = wishlist.ApplicationUserId,
            };

            foreach (var wishlistItem in wishlist.WishlistItems)
            {
                var wishlistItemViewModel = new WishlistItemViewModel
                {
                    ProductId = wishlistItem.Product.ID,
                    ProductName = wishlistItem.Product.Name,
                    ProductImage = wishlistItem.Product.ImageUrl,
                    Price = wishlistItem.Product.Price
                };
                wishlistViewModel.Items.Add(wishlistItemViewModel);
            }

            return wishlistViewModel;
        }
        public Wishlist GetWishlistByUserId(string userId)
        {
            return _context.Wishlists.Include(w => w.WishlistItems).ThenInclude(wi => wi.Product).FirstOrDefault(w => w.ApplicationUserId == userId);
        }
        public WishlistItem GetWishlistItemByProductId(int wishlistId, int productId)
        {
            return _context.WishlistItems.FirstOrDefault(wi => wi.WishlistID == wishlistId && wi.ProductID == productId);
        }
        public void CreateWishlist(Wishlist wishlist)
        {
            _context.Wishlists.Add(wishlist);
            _context.SaveChanges();
        }
        public void AddWishlistItem(WishlistItem item)
        {
            _context.WishlistItems.Add(item);
            _context.SaveChanges();
        }

        public void RemoveWishlistItem(WishlistItem item)
        {
            _context.WishlistItems.Remove(item);
            _context.SaveChanges();
        }
        public void ClearWishlist(int wishlistId)
        {
            var wishlistItems = _context.WishlistItems.Where(c => c.WishlistID == wishlistId);
            _context.WishlistItems.RemoveRange(wishlistItems);
            _context.SaveChanges();
        }

    }
}

