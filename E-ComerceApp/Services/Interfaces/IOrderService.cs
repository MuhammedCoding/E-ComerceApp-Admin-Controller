using E_ComerceApp.ViewModels;

namespace E_ComerceApp.Services.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderViewModel orderViewModel);
        OrderViewModel GetOrderById(int orderId);
        List<OrderViewModel> GetOrdersByUserId(string userId);
    }
}
