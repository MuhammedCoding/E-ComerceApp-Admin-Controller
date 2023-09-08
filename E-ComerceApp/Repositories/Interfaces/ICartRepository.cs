using E_CommerceApp.Models;

namespace E_CommerceApp.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCartById(int id);
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(int id);
    }
}
