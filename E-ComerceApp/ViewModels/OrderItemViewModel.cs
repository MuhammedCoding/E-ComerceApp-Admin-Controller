namespace E_ComerceApp.ViewModels
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}