using E_CommerceApp.Models;
using System.Diagnostics.CodeAnalysis;

namespace E_ComerceApp.ViewModels
{
    public class OrderViewModel
    {

        [AllowNull]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
