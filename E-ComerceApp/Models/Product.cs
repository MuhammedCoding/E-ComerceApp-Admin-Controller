namespace E_CommerceApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}
