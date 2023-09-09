namespace E_ComerceApp.ViewModels
{
    public class WishlistViewModel
    {
        public int WishlistId { get; set; }
        public string UserId { get; set; }
        public List<WishlistItemViewModel> Items { get; set; } = new List<WishlistItemViewModel>();
    }
}
