namespace E_CommerceApp.Models
{
    public class WishlistItem
    {
        public int ID { get; set; }
        public int WishlistID { get; set; }
        public int ProductID { get; set; }
        public Wishlist Wishlist { get; set; }
        public Product Product { get; set; }
    }
}