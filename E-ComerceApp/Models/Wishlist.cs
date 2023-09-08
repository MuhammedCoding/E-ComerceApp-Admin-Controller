namespace E_CommerceApp.Models
{
    public class Wishlist
    {
        public int ID { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
