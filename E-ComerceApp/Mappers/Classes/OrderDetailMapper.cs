//using E_ComerceApp.Mappers.Interfaces;
//using E_ComerceApp.ViewModels;
//using E_CommerceApp.Models;

//namespace E_ComerceApp.Mappers.Classes
//{
//    public static class OrderDetailMapper : IOrderDetailMapper
//    {
//        public static CartItemViewModel MapOrderDetailToViewModel(OrderDetail orderDetail)
//        {
//            return new CartItemViewModel
//            {
//                ProductId = orderDetail.Product.ID,
//                ProductName = orderDetail.Product.Name,
//                ProductImage = orderDetail.Product.ImageUrl,
//                Quantity = orderDetail.Quantity,
//                Price = orderDetail.Product.Price
//            };
//        }

//        public static OrderDetail MapViewModelToOrderDetail(CartItemViewModel viewModel)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
