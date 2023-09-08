using E_ComerceApp.Entities;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

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

        public void CreateWishlist(Wishlist wishlist)
        {
            _context.Wishlists.Add(wishlist);
            _context.SaveChanges();
        }

        public void UpdateWishlist(Wishlist wishlist)
        {
            _context.Wishlists.Update(wishlist);
            _context.SaveChanges();
        }

        public void DeleteWishlist(int id)
        {
            var wishlist = _context.Brands.Find(id);
            _context.Brands.Remove(wishlist);
            _context.SaveChanges();
        }

    }
}

