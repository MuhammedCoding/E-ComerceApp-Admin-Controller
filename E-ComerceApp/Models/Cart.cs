namespace E_CommerceApp.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}