namespace E_ComerceApp.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal TotalPrice { get; set; }
    }
}
