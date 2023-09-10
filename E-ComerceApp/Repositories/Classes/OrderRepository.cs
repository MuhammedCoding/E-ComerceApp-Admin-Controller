using E_ComerceApp.Entities;
using E_ComerceApp.Repositories.Interfaces;
using E_ComerceApp.ViewModels;
using E_CommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_ComerceApp.Repositories.Classes
{
    public class OrderRepository : IOrderRepository
    {
        private readonly E_CommerceEntities _context;
        public OrderRepository(E_CommerceEntities context)
        {
            _context = context;
        }
        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public OrderViewModel GetOrderViewModel(string userId)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.ApplicationUserId == userId);

            if (order == null)
            {
                return null;
            }

            var orderViewModel = new OrderViewModel
            {
                OrderId = order.ID,
                UserId = order.ApplicationUserId,
                TotalPrice = order.OrderDetails.Sum(ci => ci.Quantity * ci.Product.Price)
            };

            foreach (var orderDetail in order.OrderDetails)
            {
                var orderItemViewModel = new OrderItemViewModel
                {
                    ProductId = orderDetail.Product.ID,
                    ProductName = orderDetail.Product.Name,
                    ProductImage = orderDetail.Product.ImageUrl,
                    Quantity = orderDetail.Quantity,
                    Price = orderDetail.Product.Price
                };
                orderViewModel.OrderItems.Add(orderItemViewModel);
            }

            return orderViewModel;
        }
        public OrderDetail GetOrderItemByProductId(int orderId, int productId)
        {
            return _context.OrderDetails.FirstOrDefault(od => od.OrderID == orderId && od.ProductID == productId);
        }
        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }
        public List<Order> GetOrdersByUserId(string userId)
        {
            return _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(i => i.Product)
            .Where(o => o.ApplicationUserId == userId)
            .ToList();
        }
    }
}
