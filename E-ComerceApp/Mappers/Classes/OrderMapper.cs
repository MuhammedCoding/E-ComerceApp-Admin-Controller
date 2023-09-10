//using E_ComerceApp.Mappers.Interfaces;
//using E_ComerceApp.ViewModels;
//using E_CommerceApp.Models;
//using E_CommerceApp.ViewModels;

//namespace E_ComerceApp.Mappers.Classes
//{
//    public class OrderMapper:IOrderMapper
//    {

//        OrderViewModel MapOrderToViewModel(Order order)
//        {
//            return new OrderViewModel
//            {
//                OrderId = order.ID,
//                OrderDate = order.OrderDate,
//                UserId = order.ApplicationUserId,
//                PhoneNumber = order.PhoneNumber,
//                Address = order.Address,
//                OrderItems = order.OrderDetails.Select(od => OrderDetailMapper.MapOrderDetailToViewModel(od)).ToList();
//            }

//        Order MapViewModelToOrder(OrderViewModel orderViewModel)
//        {
//            return new Order
//            {
//                ID = orderViewModel.OrderId,
//                OrderDate = orderViewModel.OrderDate,
//                ApplicationUserId = orderViewModel.UserId,
//                PhoneNumber = orderViewModel.PhoneNumber,
//                Address = orderViewModel.Address,
//                OrderDetails = orderViewModel.OrderItems.Select(od => OrderDetailMapper.MapToOrderDetail(od)).ToList()
//            };
//        }
//    }
//}
