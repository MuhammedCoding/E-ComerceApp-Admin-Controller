using E_ComerceApp.Repositories.Interfaces;
using E_ComerceApp.Services.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Classes;
using E_CommerceApp.Repositories.Interfaces;

namespace E_ComerceApp.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        public void MakeOrder(OrderViewModel orderViewModel)
        {
            var cart = _cartRepository.GetCartByUserId(orderViewModel.UserId);
            var order = new Order
            {
                ID = orderViewModel.OrderId,
                OrderDate = orderViewModel.OrderDate,
                ApplicationUserId = orderViewModel.UserId,
                PhoneNumber = orderViewModel.PhoneNumber,
                Address = orderViewModel.Address,
                OrderDetails = cart.CartItems.Select(ci => new OrderDetail
                {
                    OrderID = orderViewModel.OrderId,
                    ProductID = ci.ProductID, 
                    Quantity = ci.Quantity, 
                    Product = ci.Product,
                }).ToList()
            };

            _orderRepository.CreateOrder(order);
            _cartRepository.ClearCart(cart.ID);
        }

        public OrderViewModel GetOrderById(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return null;
            }

            var orderViewModel = new OrderViewModel
            {
                OrderId = order.ID,
                UserId = order.ApplicationUserId,
                TotalPrice = order.OrderDetails.Sum(od => od.Quantity * od.Product.Price),
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,
                OrderDate = order.OrderDate
            };

            orderViewModel.OrderItems = order.OrderDetails.Select(od => new OrderItemViewModel
            {
                OrderId = od.OrderID,
                ProductId = od.ProductID,
                Quantity = od.Quantity,
                Price = od.Product.Price,
                ProductName = od.Product.Name,
                ProductImage = od.Product.ImageUrl
            }).ToList();

            return orderViewModel;
        }
        public List<OrderViewModel> GetOrdersByUserId(string userId)
        {
            var orders = _orderRepository.GetOrdersByUserId(userId);

            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.ID,
                OrderDate = o.OrderDate,
                UserId = o.ApplicationUserId,
                PhoneNumber = o.PhoneNumber,
                Address = o.Address,
                TotalPrice = o.OrderDetails.Sum(od => od.Quantity * od.Product.Price),
                OrderItems = o.OrderDetails.Select(od => new OrderItemViewModel
                {
                    OrderId = od.ID,
                    ProductId = od.ProductID,
                    Quantity = od.Quantity,
                    Price = od.Product.Price,
                    ProductName = od.Product.Name,  
                    ProductImage = od.Product.ImageUrl  
                }).ToList()
            }).ToList();

            return orderViewModels;
        }
    }
}
