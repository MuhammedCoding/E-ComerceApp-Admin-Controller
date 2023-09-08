using E_ComerceApp.Entities;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

namespace E_CommerceApp.Repositories.Classes
{
    public class CartRepository : ICartRepository
    {
        private readonly E_CommerceEntities _context;

        public CartRepository(E_CommerceEntities context)
        {
            _context = context;
        }

        public Cart GetCartById(int id)
        {
            return _context.Carts.Find(id);
        }

        public void CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }

        public void DeleteCart(int id)
        {
            var cart = _context.Brands.Find(id);
            _context.Brands.Remove(cart);
            _context.SaveChanges();
        }

    }
}

