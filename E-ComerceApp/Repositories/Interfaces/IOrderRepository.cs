using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_ComerceApp.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Order GetOrderById(int orderId);
        List<Order> GetOrdersByUserId(string userId);
        OrderViewModel GetOrderViewModel(string userId);

    }
}
